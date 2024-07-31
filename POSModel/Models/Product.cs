using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class Product
	{

		public string VendorTitle { get; set; }
		public int ProductCategoryID { get; set; }
		public string ProductCategoryTitle { get; set; }
		public double InventoryCoverage { get; set; }
		public string InventoryQuantityTitle { get; set; }
		public string CreatedByFullName { get; set; }
		public int? GroupingID { get; set; }
		public string CoverageInfo { get; set; }
		public string UnitMeasure { get; set; }
		public string TotalUOM { get; set; }
		public string TotalCoverage { get; set; }
		public string TotalQuantityWithUnit { get; set; }
		public byte[] ProductQR { get; set; }
		public string UpdateByUserName { get; set; }
		public int TaxType { get; set; }
		public int B2BTempProductID { get; set; }
		public decimal PickedUpQuantity { get; set; }
		public decimal AvailableQuantity { get; set; }
		public decimal RemainingQuantity { get; set; }
		public decimal PreparedQuantity { get; set; }
		public int InventoryProductID { get; set; }
		public int ProductID { get; set; }
		public int VendorID { get; set; }
		public string SKU { get; set; }
		public string ProductImage { get; set; }
		public string ProductName { get; set; }
		public string Style { get; set; }
		public string Color { get; set; }
		public string Description { get; set; }
		public decimal UnitCost { get; set; }
		public decimal? SalesPrice { get; set; }
		public int Association { get; set; }
		public string JobAssociation { get; set; }
		public DateTime CreatedDate { get; set; }
		public int CreatedBy { get; set; }
		public string B2BProductUniqueNumber { get; set; }
		public string ActualProductName { get; set; }
		public string ActualStyle { get; set; }
		public string ActualColor { get; set; }
		public decimal ProductQuantity { get; set; }
		public int Visible { get; set; }
		public int Discontinued { get; set; }
		public bool IsStock { get; set; }
		public int InventoryUnit { get; set; }
		public int MinimumQuantityThreshhold { get; set; }
		public int Notify { get; set; }
		public int GroupingType { get; set; }
		public decimal Coverage { get; set; }
		public string QuantityUnit { get; set; }
		public string ProductNotes { get; set; }
		public string JobID { get; set; }
		public string ServiceType { get; set; }
		public int TotalCount { get; set; }
		public decimal QuantitySold { get; set; }
		public decimal? DefaultMarginPercent { get; set; }
		public string Category { get; set; }
		public string UOM { get; set; }
		public string InventoryUnitTitle { get; set; }
		public bool QuantityRoundOff { get; set; }
		public bool Sample { get; set; }
		public string Collection { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public decimal? SalesmanMin { get; set; }
		public decimal? SalesmanMax { get; set; }
		public decimal FreightAmount { get; set; }
		public decimal SellingPrice { get; set; }
		public decimal ProductCost { get; set; }
		public int CountProducts { get; set; }
		public string QBReferenceID { get; set; }
		public decimal ProductLineItemMaxQuantity { get; set; }
		public string TotalAvailableQuantity { get; set; }
		public string StockLocation { get; set; }
		public string CoverageWithUnit { get; set; }
		public DateTime? LastOrderDate { get; set; }
		public DateTime? EffectiveByDate { get; set; }
		public int ConvertedFromProductID { get; set; }
		public decimal? CustomerSalesPrice { get; set; }
		public string WareHouseLocations { get; set; }
		public decimal OriginalProductCost { get; set; }
		public bool? IsFreightPercentage { get; set; }
		public decimal? FreightPercentage { get; set; }
		public decimal? INVCustomerPrice { get; set; }
		public decimal? INVProductPrice { get; set; }
		public decimal? INVPriceMargin { get; set; }
		public decimal InclusivePrice { get; set; }
		public bool IsRollGood { get; set; }
		public int ProductCostUnit { get; set; }
		public decimal CarpetWidthValue { get; set; }
		public decimal CarpetLengthValue { get; set; }
		public string Weight { get; set; }
		public int WarrantyID { get; set; }
		public decimal CarpetRollPrice { get; set; }
		public int StylePriceCodeID { get; set; }
		public string StyleCode { get; set; }
		public string PatternRepeat { get; set; }
		public int FiberBrandID { get; set; }
		public DateTime? DroppedDate { get; set; }
		public decimal RegularPrice { get; set; }
		public decimal PalletPrice { get; set; }
		public int RegularPriceUnit { get; set; }
		public int PalletPriceUnit { get; set; }
		public string Species { get; set; }
		public string Finish { get; set; }
		public string ColorCode { get; set; }
		public decimal Thickness { get; set; }
		public decimal VaneerThickness { get; set; }
		public decimal WearLayer { get; set; }
		public string Material { get; set; }
		public decimal PieceHeightValue { get; set; }
		public bool SyncEcommerce { get; set; }
		public int WCProductId { get; set; }

		public bool IsProductLowInQuantity
		{
			get
			{
				if (MinimumQuantityThreshhold > 0 && AvailableQuantity <= MinimumQuantityThreshhold && GroupingID > 0)
				{
					return true;
				}
				return false;
			}
		}

		public int InventoryID { get; set; }
		public decimal ShortageQty { get; set; }
		public string UOMTitle { get; set; }
		public string GroupingTitle { get; set; }
		public decimal RequiredQty { get; set; }
		public decimal AvailableQty { get; set; }
		public string UPC { get; set; }

	}
}
