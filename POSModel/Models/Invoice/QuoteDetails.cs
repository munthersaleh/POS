using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class QuoteDetails
	{
		public QuoteDetails()
		{
			QuoteTotal = new Total();
			QuoteProfit = new Profit();
			QuoteDiscount = new Discount();
			QuoteCommission = new Commission();
			CommissionSetting = new CommissionSetting();
			AmountDueInfo = new InvoicePaidAmount();
		}
		public int InvoiceTypeID { get; set; }
		public int MarginCalculateType { get; set; }
		public decimal? TaxRate { get; set; }
		public bool? TaxExempt { get; set; }
		public decimal? PSTTaxRate { get; set; }
		public decimal TotalMaterial { get; set; }
		public decimal TotalLabor { get; set; }
		public decimal TotalSalesMaterial { get; set; }
		public decimal TotalSalesLabor { get; set; }
		public int? EmployeeID { get; set; }
		public decimal? DownpaymentAmount { get; set; }
		public decimal? DownpaymentPercentage { get; set; }
		public Total QuoteTotal { get; set; }
		public Profit QuoteProfit { get; set; }
		public Discount QuoteDiscount { get; set; }
		public Commission QuoteCommission { get; set; }
		public CommissionSetting CommissionSetting { get; set; }
		public IEnumerable<CommissionSetting> Commissions { get; set; }
		public InvoicePaidAmount AmountDueInfo { get; set; }
		public bool TaxCalculationAfterDiscount { get; set; }
		public bool SalesTaxAsCost { get; set; }
		public bool CalcMarginBeforeTax { get; set; }
		public decimal MaterialOverheadPercentage { get; set; }
		public decimal LaborOverheadPercentage { get; set; }
		public decimal SubTotalOverheadPercentage { get; set; }
		public bool ApplyMaterialOverheadToSellPrice { get; set; }
		public bool ApplyLaborOverheadToSellPrice { get; set; }
		public string CustomCommType { get; set; }
		public decimal CustomCommValue { get; set; }
		public LocationInfo LocationSettings { get; set; }
		public int DiscountApply { get; set; }
		public int CommissionType { get; set; }
		public decimal NetSales { get; set; }
		public decimal NetCost { get; set; }
	}
}
