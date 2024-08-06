using POSModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class Material : LineItemDetails
	{
		public int QuoteProductID { get; set; }
		public int QuoteID { get; set; }
		public string RandomServiceTypeID { get; set; }
		public int? OriginalProductID { get; set; }
		public bool? ShowInQuote { get; set; }
		public bool IsStock { get; set; }
		public string SelectedMeasurements { get; set; }
		public decimal? ShippingCost { get; set; }
		public int? UniqueMaterialID { get; set; }
		public int? Position { get; set; }
		public int? GroupingType { get; set; }
		public decimal? InventoryCoverage { get; set; }
		public string VendorTitle { get; set; }
		public string ProductImage { get; set; }
		public int ServiceTypeID { get; set; }
		public string ProductName { get; set; }
		public string SKU { get; set; }
		public string Style { get; set; }
		public string Color { get; set; }
		public string Description { get; set; }
		public bool Association { get; set; }
		public string JobAssociation { get; set; }
		public bool AddedAfterInvoiceCreated { get; set; }
		public DateTime CreatedDate { get; set; }
		public string CreatedByName { get; set; }
		public int CreatedBy { get; set; }
		public int BundleID { get; set; }
		public string BundleColor { get; set; }
		public string BundleDescription { get; set; }
		public int? BundleQuantity { get; set; }
		public string BundleName { get; set; }
		public int QuoteGroupID { get; set; }
		public string GroupName { get; set; }
		public string GroupColor { get; set; }
		public decimal? CarpetRollPrice { get; set; }
		public decimal QuoteInvoiceMaterialTax { get; set; }
		public decimal ProductLineItemMaxQuantity { get; set; }
		public string Notes { get; set; }
		public bool IsNotesInternal { get; set; }
		public decimal? TotalPickedUpQuantity { get; set; }
		public decimal ProductUnitCost { get; set; }
		public decimal ProductQuantity { get; set; }
		public bool Visible { get; set; }
		public int MinimumQuantityThreshhold { get; set; }
		public bool Notify { get; set; }
		public string RefNumber { get; set; }
		public int? GroupingID { get; set; }
		public decimal? UseTax { get; set; }
		public string UOMTitle { get; set; }
		public object NewValue { get; set; }
		public int LineItemAction { get; set; } = (int)ActionEnum.None;
		public decimal? SalesPrice { get; set; }
		public int LaborID { get; set; }
		public string LaborName { get; set; }
		public string LaborDescription { get; set; }
		public int ProductCostUnit { get; set; }
	}
}
