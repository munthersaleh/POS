using POSModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class LineItemDetails
	{
		public LineItemDetails()
		{
			LIPricingDetails = new LIPricingDetails();
		}
		public string UnitMeasure { get; set; }
		public decimal Coverage { get; set; }
		public LineItemTypeEnum QuoteLineItemType { get; set; }
		public decimal? ProductDiscountAmount { get; set; }
		public decimal? UOMUnitCost { get; set; }
		public LIPricingDetails LIPricingDetails { get; set; }
		public LineItemActionEnum Action { get; set; } = LineItemActionEnum.Added;
		public int? ProductID { get; set; }
		public int TaxType { get; set; }
		public decimal? CustomFreightAmount { get; set; }
		public int OriginalLaborID { get; set; }
		public bool? IsLineItem { get; set; }
		public int VendorID { get; set; }
		public bool QuantityRoundOff { get; set; }
		public decimal ProductDiscount { get; set; }
		public int ProductDiscountType { get; set; }
		public int ProductCategoryID { get; set; }
		public bool? IsFreightPercentage { get; set; }
		public decimal? FreightPercentage { get; set; }
		public decimal FreightAmount { get; set; }
		public bool? IsCustomFreightRemoved { get; set; }
		/// <summary>
		/// Applicable for UnitPrice and TotalPrice
		/// Validates if the sales price was explicitely set by the customer.
		/// If it is explicitely set by the customer sales price should remain as it,
		/// and impact should be forwarded to other properties.
		/// </summary>
		public bool IsCustomSalesPrice { get; set; }
		public decimal CustomSalesPrice { get; set; }
		public decimal? UOM { get; set; }
		public decimal? CustomUOM { get; set; }
		public string ProductCategoryTitle { get; set; }
		public bool? IsRollGood { get; set; }
		public int InventoryUnit { get; set; }
		public decimal? CarpetLF { get; set; }
		public decimal? CarpetYD { get; set; }
		public decimal? CarpetSQ { get; set; }
		public decimal CarpetWidthValue { get; set; }
		public decimal? CarpetLengthValue { get; set; }
		public string InventoryQuantityTitle { get; set; }
		public string InventoryUnitTitle { get; set; }

		public decimal SalesTax { get; set; }
		public decimal MaterialTax { get; set; }
		public decimal PSTTax { get; set; }
		public decimal UseTaxValue { get; set; }
	}
}
