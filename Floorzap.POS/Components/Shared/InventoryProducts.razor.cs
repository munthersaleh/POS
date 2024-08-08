using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
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
		[Parameter]
		public EventCallback<HashSet<Product>> OnAddProducts { get; set; }

		[Inject]
        IProductService productService { get; set; }


		private HashSet<Product> selectedItems = new HashSet<Product>();

		private MudTable<Product> table;

		private int totalItems;
		private string searchString = null;

		private int stockType = 1;

		private async Task AddSelectedProducts()
		{
			await OnAddProducts.InvokeAsync(selectedItems);
			selectedItems = new HashSet<Product>();
		}

		private async Task<TableData<Product>> ServerReload(TableState state, CancellationToken token)
		{
			InventoryProductFilterModel filterModel = new InventoryProductFilterModel
			{
				Association = false,
				FilterByProductName = searchString ?? "",
				PageType = 0,
				PaginationModel = new PaginationModel
				{
					Skip = state.Page * state.PageSize,
					Take = state.PageSize,
					PageSize = state.PageSize,
					Page = state.Page
				},
				ServiceTypeID = 1231
			};
			filterModel.IsStock = stockType;

			List<Product> filteredProducts = await productService.GetAllProductsServerPaginated(filterModel);
			totalItems = filteredProducts.Any() ? filteredProducts.FirstOrDefault().TotalCount : 0;

			return new TableData<Product>
			{
				TotalItems = totalItems,
				Items = filteredProducts
			};
		}

        private void OnSearch(string text)
		{
			searchString = text;
			table.ReloadServerData();
		}

		private void FilterTableByStock(int stockType)
		{
			this.stockType = stockType;
			table.ReloadServerData();
		}

	}
}
