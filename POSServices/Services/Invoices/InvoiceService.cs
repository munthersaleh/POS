using POSModel.Enums;
using POSModel.Models;
using POSServices.Helpers;
using POSServices.HttpApiManager;
using POSServices.Services.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Invoices
{
	public class InvoiceService : IInvoiceService
	{
		private readonly IApiManager _apiManager;
		private readonly ICompanyService _companyService;
		CompanySettings companySettings = new CompanySettings();
		public InvoiceService(IApiManager apiManager,ICompanyService companyService)
		{
			_apiManager = apiManager;
			_companyService = companyService;
		}

		public async Task<CreateInvoiceRequest> CreateInvoiceObject(){
			CreateInvoiceRequest newInvoice = new CreateInvoiceRequest();
			try
			{
				await GetAllRequiredData();
				await Task.WhenAll(
					CreateInvoiceDetails(newInvoice),
					CreateInvoiceData(newInvoice)
					);
				return newInvoice;
			}
			catch (Exception ex)
			{
				return new CreateInvoiceRequest();
			}
		}
		private async Task GetAllRequiredData()
		{
			companySettings = AppConstants.companySettings;
		}
		private async Task CreateInvoiceDetails(CreateInvoiceRequest newInvoice)
		{
			InvoiceDetailRequest invoiceDetail = new InvoiceDetailRequest()
			{
				QuoteID = 0,
				QuoteStatus = 23,
				CustomerID = 0,
				EmployeeID = 1,
				LocationID = 1, // update it later
								//AddressID = 2,
				QuoteInvoiceName = string.Empty,
				MarginCalculateType = companySettings.CalculateMarginPercentBasedOn,
				SalesTaxAsCost = companySettings.SalesTaxAsCost,
				TaxCalculationAfterDiscount = companySettings.TaxCalculationAfterDiscount,
				MaterialOverheadPercentage = companySettings.MaterialOverheadPercentage ?? 0,
				ApplyMaterialOverheadToSellPrice = companySettings.ApplyMaterialOverheadToSellPrice ?? false,
				LaborOverheadPercentage = companySettings.LaborOverheadPercentage ?? 0,
				ApplyLaborOverheadToSellPrice = companySettings.ApplyLaborOverheadToSellPrice ?? false,
				SubTotalOverheadPercentage = companySettings.SubTotalOverheadPercentage ?? 0,
				QuoteInvoiceOriginalCreatedDate = DateTime.Now,
				QuoteInvoiceCreatedDate = DateTime.Now,
				MaterialOnly = GetMaterialOnly(),
				InvoiceCategory = 2, // cash and carry
				InvoiceTypeID = 1 // material only
			};
			newInvoice.InvoiceDetail = invoiceDetail;
		}

		private MaterialOnly GetMaterialOnly()
		{
			var matOnly = new MaterialOnly { CashAndPickup = new CashAndPickup(), CashAndDelivery = new CashAndDelivery() };

			//cash and pickup
			if ("cashandpickup" == "cashandpickup")
			{
				var pickupDate = DateTime.Now;


				matOnly.CashAndPickup = new CashAndPickup
				{
					PickUpDate = pickupDate,
					Notes = "We did cash and pickup",
					LocationID = 2
				};
				matOnly.CashAndDelivery = null;
				return matOnly;
			}
			//cash and delivery
			else if ("" == "cashanddelivery")
			{
				var deliveryDateTime = DateTime.Now;

				matOnly.CashAndDelivery = new CashAndDelivery
				{
					DeliveryDateTime = deliveryDateTime,
					Notes = "We did cash and delivery",
					AddressID = 2 // change to customer id
				};

				matOnly.CashAndPickup = null;
				return matOnly;
			}

			return null;
		}
		private async Task CreateInvoiceData(CreateInvoiceRequest newInvoice)
		{
			InvoiceResponse invoiceData = new InvoiceResponse()
			{
				QuoteID = 0,
				QuoteStatus = 23,
				QuoteInvoiceName = string.Empty,
				CustomerID = 0,
				EmployeeID = 1,
				LocationID = 1, //update it later
				MarginCalculateType = companySettings.CalculateMarginPercentBasedOn,
				SalesTaxAsCost = companySettings.SalesTaxAsCost,
				TaxCalculationAfterDiscount = companySettings.TaxCalculationAfterDiscount,
				CalcMarginBeforeTax = true,
				MaterialOverheadPercentage = companySettings.MaterialOverheadPercentage ?? 0,
				ApplyMaterialOverheadToSellPrice = companySettings.ApplyMaterialOverheadToSellPrice ?? false,
				LaborOverheadPercentage = companySettings.LaborOverheadPercentage ?? 0,
				ApplyLaborOverheadToSellPrice = companySettings.ApplyLaborOverheadToSellPrice ?? false,
				SubTotalOverheadPercentage = companySettings.SubTotalOverheadPercentage ?? 0,
				//QuoteInvoiceOriginalCreatedDate = DateTime.Now,
				//QuoteInvoiceCreatedDate = DateTime.Now,
				MaterialOnly = GetMaterialOnly()

			};
			newInvoice.InvoiceData = invoiceData;
			newInvoice.InvoiceData.ServiceTypes.Add(await CreateServiceType());
			
		}
		private static readonly System.Random Random = new System.Random();

		public static string MakeRandomId()
		{
			// Generate a random letter from 'A' to 'Z'
			char randLetter = (char)('A' + Random.Next(0, 26));

			// Get the current timestamp in milliseconds since the Unix epoch
			long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

			// Combine the letter and timestamp
			return $"{randLetter}{timestamp}";
		}
		private async Task<ServiceTypeItem> CreateServiceType()
		{
			SystemList cashAndCarry = AppConstants.allSystemLists.FirstOrDefault(s => s.Title.ToLower() == "Cash and Carry".ToLower()); // system list id for cash and carry // 2242
			int jobTypeId = cashAndCarry.SystemListID;
			string jobTypeName = cashAndCarry.Title;
			// get service type tax setting from the database

			ServiceTypeItem serviceTypeItem = new ServiceTypeItem()
			{
				ServiceTypeID = 0,
				JobTypeID = jobTypeId,
				JobTypeName = jobTypeName,
				RandomID = MakeRandomId(),
				TotalSQ = 0,
				TotalMargin = 0,
				ContractorReadyForPayment = false,
				ContractorID = 0,
				LaborStatus = 0,
				ScheduleNotes = null,
				Materials = new List<Material>(),
				//ApplyPSTTax = companySettings[0]?.ApplyPSTTax ?? 0,
				CreatedBy = 1, // Logged user Id
				Action = (int)ActionEnum.Added,
				//ShowUseTax = companySettings[0].CalculateUseTax,
				//InvoiceTypeID = 0, // Replace with actual InvoiceTypeID
				//InvoiceTypes = null, // Replace with actual InvoiceTypes
				//IsUseTax = isUseTax,
				MaterialAndLaborUseTax = true,
				MaterialOnlyUseTax = true,
				EnableSalesTax = true
			};
			return serviceTypeItem;

		}
		public async Task<CreateInvoiceRequest> CreateInvoice(CreateInvoiceRequest invoice)
		{ 
			try
			{
				var response = await _apiManager.PostAsync<CreateInvoiceRequest>(AppConstants.baseAddress + "/invoicefeature/CreateInvoice", invoice);
				if (response != null)
				{
					var res = await _apiManager.PostAsync<object>(AppConstants.baseAddress + "/Invoice/CreateInvoice?quoteId=" + response.InvoiceData.QuoteID , null);
				}
				return response;
			}
			catch (Exception ex)
			{
				return new CreateInvoiceRequest();
			}
			 
		}
	}
}
