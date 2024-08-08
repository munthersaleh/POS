using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Microsoft.Maui.ApplicationModel;
using POSModel.Enums;
using POSModel.Models;
using POSServices.Helpers;
using POSServices.Services.Calculations;
using POSServices.Services.Company;
using POSServices.Services.Customers;
using POSServices.Services.Invoices;
using POSServices.Services.Locations;
using POSServices.Services.Products;
using POSServices.Services.SystemLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MudBlazor;
using Microsoft.Maui.Devices.Sensors;
namespace Floorzap.POS.Components.Pages
{
	public partial class ProductOrder
	{

        private string cashPayment = "selected-payment";
        private string cardPayment = "unselected-payment";

        List<CustomerInfo> allCustomers = new List<CustomerInfo>();
        List<CustomerInfo> filteredCustomers = new List<CustomerInfo>();
        List<CartProduct> cartProducts = new List<CartProduct>();


		CustomerInfo selectedCustomer;
        CustomerAddress customerAddress = new CustomerAddress();
        CompanySettings companySettings = new CompanySettings();
        int selectedCustomerId = -1;
        decimal subTotal = 0;
        decimal salesTax = 0;
        decimal totalPrice = 0;
        string searchTerm = string.Empty;
        string searchCustomer = string.Empty;
		CreateInvoiceRequest invoice = new CreateInvoiceRequest();
        [Inject]
        IProductService productService { get; set; }

        [Inject]
        ICustomerService customerService { get; set; }
		[Inject]
		ICompanyService companyService { get; set; }

		[Inject]
        IJSRuntime JSRuntime { get; set; }
        [Inject]
        NavigationManager navigationManager { get; set; }
		[Inject]
		IInvoiceService invoiceService { get; set; }
		[Inject]
		ISystemListService systemListService { get; set; }
        [Inject]
        ICalculationService calculationService { get; set; }
        [Inject]
        ILocationService locationService { get; set; }
        [Inject]
        ISnackbar snackbar { get; set; }
        public int selectedLocationID { get; set; }

        int materialRowCount = 0;
        private bool isShownCustomerList = false;

		private bool dataLoaded = false;

        public List<LocationDetails> allLocations { get; set; }
        protected override async Task OnInitializedAsync()
        {
			dataLoaded = false;
			allCustomers = await customerService.GetAllCustomers();
            companySettings = await companyService.GetCompanySettingsAsync();
            AppConstants.allSystemLists = await systemListService.GetAllSystemList(); //

            await CreateEmptyInvoice();
            allLocations = await locationService.GetAllLocations();
            if (allLocations != null && allLocations.Count > 0)
            {
                selectedLocationID = allLocations[0].LocationID;
                invoice.InvoiceData.TaxRate = allLocations[0].SalesTax;
                invoice.InvoiceDetail.LocationID = selectedLocationID;
                invoice.InvoiceData.TaxSource = 2; //location
            }
            dataLoaded = true;
		}

        private void OnSelectionChanged(int locationID)
        {
            selectedLocationID = locationID;
            invoice.InvoiceDetail.LocationID = locationID;
            invoice.InvoiceData.TaxRate = allLocations.FirstOrDefault(l => l.LocationID == selectedLocationID).SalesTax;
        }


        private async void GetAllCustomers()
        {
            if (string.IsNullOrEmpty(searchCustomer))
            {
				filteredCustomers = allCustomers;
            }
            else
            {
                filteredCustomers = allCustomers
                    .Where(p => p.FullName.Contains(searchCustomer, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            isShownCustomerList = true;
        }
        private bool customerChanged = true;
        private async Task ChangeCustomer(CustomerInfo customer)
        {
			customerChanged = false;
            selectedCustomer = customer;
            searchCustomer = customer.FullName;
            isShownCustomerList = false;
            customerAddress = await customerService.GetDefaultAddressByCustomerID(customer.CustomerID);
			await UpdateInvoiceCustomer();
            customerChanged = true;
           
        }

		private async Task UpdateInvoiceCustomer()
		{
			invoice.InvoiceDetail.CustomerID = selectedCustomer.CustomerID;
			invoice.InvoiceDetail.AddressID = customerAddress.AddressID;
			invoice.InvoiceDetail.QuoteInvoiceName = selectedCustomer.FullName + selectedCustomer.CustomerID.ToString();
		}

        public void HandleCustomerSearchInput(ChangeEventArgs args)
        {
            searchCustomer = args.Value.ToString();

            if (!string.IsNullOrEmpty(searchCustomer))
            {
                filteredCustomers = allCustomers
                    .Where(p => p.FullName.Contains(searchCustomer, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            else
            {
                filteredCustomers = allCustomers;
            }
        }
        
        private void ChangePaymentMethod(bool isCashMethod)
        {
            if (isCashMethod)
            {
                cashPayment = "selected-payment";
                cardPayment = "unselected-payment";
            }
            else
            {
                cashPayment = "unselected-payment";
                cardPayment = "selected-payment";
            }
        }

        private async Task AddCartsItems(HashSet<Product> products)
        {
			List<Material> newAddedMaterials = new List<Material>();
            foreach(var product in products)
            {
               Material newMaterial =  await MapProductToMaterial(product);
               invoice.InvoiceData.ServiceTypes[0].Materials.Add(newMaterial);
                newAddedMaterials.Add(newMaterial);
            }
			await AddMultipleLineItems(newAddedMaterials);	
        }

		private async Task CreateEmptyInvoice()
		{
			invoice = await invoiceService.CreateInvoiceObject();
		}

		private async Task AddMultipleLineItems(List<Material> newAddedMaterials)
		{
            InvoiceResponse updateInvoice = JsonSerializer.Deserialize<InvoiceResponse>(JsonSerializer.Serialize(invoice.InvoiceData));
            updateInvoice.ServiceTypes[0].Materials = [];
            updateInvoice.ServiceTypes[0].Materials = newAddedMaterials;
            updateInvoice.Action = QuoteActionEnum.LineItemAdded;
            InvoiceResponse updatedInvoiceData = await calculationService.AddMultipleLineItems(updateInvoice);
			if(updatedInvoiceData != null)
			{
                if (updatedInvoiceData.ServiceTypes[0].Action == (int)ActionEnum.None)
                {
                    updatedInvoiceData.ServiceTypes[0].Action = (int)ActionEnum.Modified;
                }
                foreach(var mat in updatedInvoiceData.ServiceTypes[0].Materials)
                {
                    mat.LineItemAction = (int)ActionEnum.Added;
                    await UpdateMaterialInInvoice(mat);
                }
                await UpdateInvoice(updatedInvoiceData);
            }
            
        }

		private async Task UpdateLineItem(LineItemData lineItemData)
		{
			InvoiceResponse updateInvoice = JsonSerializer.Deserialize<InvoiceResponse>(JsonSerializer.Serialize(invoice.InvoiceData));
            Material updateMaterial = findMaterialByUniqueID(lineItemData.LineItemID);
			updateInvoice.ServiceTypes[0].Materials = [];
			updateMaterial.Action = lineItemData.LineItemAction;
			updateMaterial.NewValue = lineItemData.NewValue;
            updateInvoice.ServiceTypes[0].Materials.Add(updateMaterial);
			updateInvoice.Action = QuoteActionEnum.LineItemUpdated;
            InvoiceResponse updatedInvoiceData = await calculationService.UpdateLineItem(updateInvoice);
			if(updatedInvoiceData != null)
			{
				if (updatedInvoiceData.ServiceTypes[0].Action == (int)ActionEnum.None) updatedInvoiceData.ServiceTypes[0].Action = (int)ActionEnum.Modified;
                if (updatedInvoiceData.ServiceTypes[0].Materials[0].LineItemAction == (int)ActionEnum.None) updatedInvoiceData.ServiceTypes[0].Materials[0].LineItemAction = (int)ActionEnum.Modified;
                await UpdateMaterialInInvoice(updatedInvoiceData.ServiceTypes[0].Materials[0]);
                await UpdateInvoice(updatedInvoiceData);
			}
		}


        private async Task DeleteLineItem(int? uniqueMaterialId)
        {
            InvoiceResponse updateInvoice = JsonSerializer.Deserialize<InvoiceResponse>(JsonSerializer.Serialize(invoice.InvoiceData));
            Material updateMaterial = findMaterialByUniqueID(uniqueMaterialId);
            updateInvoice.ServiceTypes[0].Materials = [];
            updateInvoice.ServiceTypes[0].Materials.Add(updateMaterial);
            updateInvoice.Action = QuoteActionEnum.LineItemRemoved;
            InvoiceResponse updatedInvoiceData = await calculationService.DeleteLineItem(updateInvoice);
            if (updatedInvoiceData != null)
            {
                if (updatedInvoiceData.ServiceTypes[0].Action == (int)ActionEnum.None) updatedInvoiceData.ServiceTypes[0].Action = (int)ActionEnum.Modified;
                updatedInvoiceData.ServiceTypes[0].Materials[0].LineItemAction = (int)ActionEnum.Deleted;
                await UpdateMaterialInInvoice(updatedInvoiceData.ServiceTypes[0].Materials[0]);
                await UpdateInvoice(updatedInvoiceData);
            }
        }

        private async Task UpdateInvoice(InvoiceResponse updatedInvoice)
        {
			await UpdateServiceTypeInInvoice(updatedInvoice);
            await UpdateInvoiceData(updatedInvoice);
			await UpdateValuesInUI();
        }

        private async Task UpdateMaterialInInvoice(Material material)
        {
            int materialIndex = findMaterialIndex(material.UniqueMaterialID);
            if (materialIndex != -1)
            {
                invoice.InvoiceData.ServiceTypes[0].Materials[materialIndex] = material;
            }
            
        }
        private async Task UpdateServiceTypeInInvoice(InvoiceResponse updatedInvoice)
        {
			updatedInvoice.ServiceTypes[0].Materials = invoice.InvoiceData.ServiceTypes[0].Materials;
			invoice.InvoiceData.ServiceTypes = updatedInvoice.ServiceTypes;
        }
        private async Task UpdateInvoiceData(InvoiceResponse updatedInvoice)
        {
            updatedInvoice.ServiceTypes = invoice.InvoiceData.ServiceTypes;
            invoice.InvoiceData = updatedInvoice;
        }

        private async Task UpdateValuesInUI()
        {
			subTotal = invoice.InvoiceData.QuoteTotal.SubTotal;
            totalPrice = invoice.InvoiceData.QuoteTotal.TotalSale;
            salesTax = invoice.InvoiceData.QuoteTotal.SalesTax;
            StateHasChanged();
        }


        public int findMaterialIndex(int? uniqueMaterialId)
        {
            if (invoice.InvoiceData.ServiceTypes != null && invoice.InvoiceData.ServiceTypes[0].Materials != null && invoice.InvoiceData.ServiceTypes[0].Materials.Count > 0)
            {
                var index = invoice.InvoiceData.ServiceTypes[0].Materials.FindIndex(m => m.UniqueMaterialID == uniqueMaterialId);
                return index; 
            }
            return -1;
        }
        private Material findMaterialByUniqueID(int? lineItemID)
        {
            return invoice.InvoiceData.ServiceTypes[0].Materials.Where(m => m.UniqueMaterialID == lineItemID).FirstOrDefault();
        }

        private async Task<Material> MapProductToMaterial(Product mat)
        {
			Material material = new Material()
			{
				VendorTitle = mat.VendorTitle,
				VendorID = mat.VendorID,
				//CategoryTitle = mat.CategoryTitle ?? string.Empty,
				InventoryCoverage = (decimal)mat.InventoryCoverage,
				InventoryQuantityTitle = mat.InventoryQuantityTitle ?? string.Empty,
				GroupingID = mat.GroupingID ?? 0,
				//CoverageInfo = mat.CoverageInfo ?? string.Empty,
				UnitMeasure = mat.UnitMeasure ?? string.Empty,
				InventoryUnit = mat.InventoryUnit != null ? mat.InventoryUnit : 0,
				//TotalUOM = mat.TotalUOM ,
				//TotalCoverage = mat.TotalCoverage ?? 0,
				ProductID = mat.ProductID,
				ProductLineItemMaxQuantity = mat.ProductLineItemMaxQuantity,
				OriginalProductID = mat.ProductID,
				ProductCategoryID = mat.ProductCategoryID,
				ProductCategoryTitle = mat.ProductCategoryTitle ?? string.Empty,
				ProductName = mat.ProductName?.Replace("\"", "&quot;") ?? string.Empty,
				ProductUnitCost = mat.UnitCost != null ? mat.UnitCost : 0,
				Style = mat.Style ?? string.Empty,
				Color = mat.Color ?? string.Empty,
				Description = mat.Description ?? string.Empty,
				//UnitCost = mat.UnitCost ,
				SalesPrice = mat.SalesPrice ?? 0,
				ProductQuantity = mat.ProductQuantity != null ? mat.ProductQuantity : 0,
				GroupingType = mat.GroupingType,
				Coverage = mat.Coverage,
				ProductDiscountAmount = 0,
				ProductDiscountType = 1,
                //SQF = mat.SQF ,
                //JobID = mat.JobID,
                //IsCustomSalesPrice = mat.IsCustomSalesPrice ?? false,
                IsLineItem = false,
				IsStock = mat.IsStock,
				//InvoiceLineItemType = 0,
				//OriginalLaborID = mat.OriginalLaborID ?? 0,
				//ProfitMargin = (mat.IsInvoiceLabor && mat.DefaultMarginPercent.HasValue)
				//? mat.DefaultMarginPercent.Value
				//: (mat.IsInvoiceMaterial && mat.DefaultMarginPercent.HasValue)
				//	? mat.DefaultMarginPercent.Value
				//	: (companySettings[0]?.MaxCommission ?? 0),
				CarpetWidthValue = mat.CarpetWidthValue != 0 ? mat.CarpetWidthValue : 12,
				CarpetLengthValue = mat.CarpetLengthValue != 0 ? mat.CarpetLengthValue : 0,
				CarpetRollPrice = mat.CarpetRollPrice != 0 ? mat.CarpetRollPrice : 0,
				TaxType = mat.TaxType,
				FreightAmount = mat.FreightAmount,
				FreightPercentage = mat.FreightPercentage ?? 0,
				IsFreightPercentage = mat.IsFreightPercentage ?? false,
				CustomFreightAmount = 0,
				BundleName = string.Empty,
				BundleColor = string.Empty,
				BundleID = 0,
				QuantityRoundOff = mat.QuantityRoundOff,
				IsRollGood = mat.IsRollGood,
				ProductCostUnit = mat.ProductCostUnit,
				SKU = mat.SKU,
				JobAssociation = mat.JobAssociation,
				Visible = (mat.Visible == 1) ? true : false,
				IsNotesInternal = true,

				UniqueMaterialID = materialRowCount,
				LineItemAction = (int)ActionEnum.Added,
				QuoteLineItemType = LineItemTypeEnum.Material,
				InventoryUnitTitle = mat.InventoryUnitTitle,
			};
			materialRowCount++;

            material.LIPricingDetails = new LIPricingDetails()
            {
                UnitCost = mat.UnitCost,
                Quantity = 0,
                TotalSQF = 1,
                TotalCost = 0,
                UnitPrice = mat.SellingPrice,
                IsTaxable = true,
				//Margin = (mat.IsInvoiceLabor && mat.DefaultMarginPercent.HasValue)
				//? mat.DefaultMarginPercent.Value
				//: (mat.IsInvoiceMaterial && mat.DefaultMarginPercent.HasValue)
				//	? mat.DefaultMarginPercent.Value
				//	: (companySettings[0]?.MaxCommission ?? 0),
				Margin =  mat.DefaultMarginPercent != null
							? mat.DefaultMarginPercent.Value
							: (companySettings.MaxCommission != null ? companySettings.MaxCommission : 0)

     		};
			return material;
		}
		private CartProduct MapToCartProduct(Product product)
		{
			return new CartProduct
			{
				ProductId = product.ProductID,
				Name = product.ProductName,
				Sku = product.SKU,
				Quantity = 1,
				UnitPrice = product.UnitCost,
				ItemCode = product.SKU,
				IsSaleTax = true,
                IsStock = product.IsStock
			};
		}


        private bool isSavingInvoice = false;
		
		private async Task SaveInvoice()
		{
            isSavingInvoice = true;
            if(selectedCustomer == null )
            {
                snackbar.Add("Please select customer", Severity.Error);
            }
            else if (invoice.InvoiceData.ServiceTypes[0].Materials == null || invoice.InvoiceData.ServiceTypes[0].Materials.Count == 0)
            {
                snackbar.Add("Please add products", Severity.Error);
            }
            else
            {
                CreateInvoiceRequest savedInvoice = await invoiceService.CreateInvoice(invoice);

            }
            isSavingInvoice = false;
		}

	}


}
