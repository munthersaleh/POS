using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using POSModel.Models;
using POSServices.Services.Products;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Floorzap.POS.Components.Shared
{
    public partial class InventoryProducts
    {
        List<Product> allProducts = new List<Product>();
        List<Product> filteredProducts = new List<Product>();


		private int currentPage = 1;
		private int pageSize = 15; // Default page size
		private int totalPages = 0;

		int totalProducts = 0;

		[Parameter]
		public EventCallback<List<Product>> OnAddProducts { get; set; }

		[Parameter]
		public bool IsInventory { get; set; }
		[Inject]
        IProductService productService { get; set; }
        [Inject]
        IJSRuntime JSRuntime { get; set; }
        protected override async Task OnInitializedAsync()
        {
			allProducts = await productService.GetAllInventoryProducts();
			//await LoadProducts();
		}
		private HashSet<int> selectedProductIds = new HashSet<int>(); 

		private void ToggleSelection(int productId)
		{
			if (selectedProductIds.Contains(productId))
			{
				selectedProductIds.Remove(productId);
			}
			else
			{
				selectedProductIds.Add(productId);
			}
		}

		private async Task AddSelectedProducts()
		{
			var selectedProductIdss = await JSRuntime.InvokeAsync<List<int>>("getSelectedProductIds");
			var selectedProducts = allProducts.Where(p => selectedProductIdss.Contains(p.ProductID)).ToList();
			OnAddProducts.InvokeAsync(selectedProducts);
        }

		private async Task ChangePage(int newPage)
		{
			if (newPage < 1) return;
			currentPage = newPage;
			await LoadProducts();
		}

		private async Task LoadProducts()
		{
			if (IsInventory)
			{
				InventoryProductFilterModel inventoryProductFilterModel = new InventoryProductFilterModel()
				{
					Association = false,
					FilterByColor = "",
					FilterByProductName = "",
					FilterBySKU = "",
					FilterByStyle = "",
					IsStock = -1,
					PageType = 0,
					PaginationModel = new PaginationModel()
					{
						Skip = currentPage * pageSize,
						Take = pageSize,
						PageSize = pageSize,
						Page = currentPage
					},
					ServiceTypeID = 1231
				};
				allProducts = await productService.GetAllProductsServerPaginated(inventoryProductFilterModel);
				totalProducts = allProducts.FirstOrDefault().TotalCount;
				totalPages = totalProducts / pageSize;
			}
			else
			{
				allProducts = await productService.GetAllNonInventoryProducts();
			}
		}

		//[JSInvokable]
		//public static Task OnCheckboxChanged(int productId, bool isChecked)
		//{
		//    // Handle the checkbox change
		//    // This example assumes that you have a way to manage the component's instance or state
		//    if (isChecked)
		//    {
		//        // Logic for adding productId to selectedProductIds
		//    }
		//    else
		//    {
		//        // Logic for removing productId from selectedProductIds
		//    }
		//    return Task.CompletedTask;
		//}

		//protected override async Task OnAfterRenderAsync(bool firstRender)
		//{
		//    if (firstRender)
		//    {
		//        await JSRuntime.InvokeVoidAsync("setupTableCheckboxes");
		//    }
		//}


	}
}
