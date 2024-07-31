using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class PaginationModel
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
		public int Skip { get; set; }
		public int Take { get; set; }
		public int Total { get; set; }
		public SortModel Sorting { get; set; }
	}

	public class SortModel
	{
		public string Dir { get; set; }
		public string Field { get; set; }
	}

	public class InventoryProductFilterModel
	{

		public string SearchText { get; set; }
		public string ServiceName { get; set; }
		public string ServiceType { get; set; }
		public int ServiceTypeID { get; set; }
		public int ProductCategoryID { get; set; }
		public int VendorID { get; set; }
		public bool? Association { get; set; }
		public bool Discontinued { get; set; }
		public bool Visible { get; set; }

		public bool Sample { get; set; }
		public int IsStock { get; set; }

		public string FilterByProductName { get; set; }
		public string FilterByStyle { get; set; }
		public string FilterByColor { get; set; }
		public int ProductID { get; set; }
		public bool IsProductLowInQuantity { get; set; }
		public PaginationModel PaginationModel { get; set; }
		public bool Expired { get; set; }
		public string ActualProductName { get; set; }
		public string ActualStyle { get; set; }
		public string ActualColor { get; set; }
		public string StockLocation { get; set; }
		public int PageType { get; set; }
		public string FilterBySKU { get; set; }
	}
	
}
