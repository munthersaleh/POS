using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class ServiceTypePricingDetails
	{
		// TotalMaterial
		public decimal Material { get; set; }
		// QuoteInvoiceMaterialTax
		public decimal MaterialTax { get; set; }
		// TotalUseTax
		public decimal UseTax { get; set; }
		// TotalPSTTax
		public decimal PSTTax { get; set; }
		// TotalLabor
		public decimal Labor { get; set; }
		// Not Getting Saved
		public decimal Expenses { get; set; }
		// TotalFreight
		public decimal Freight { get; set; }
		// TotalTax
		public decimal SalesTax { get; set; }
		// TotalCost
		public decimal TotalCosts { get; set; }
		// TotalSales
		public decimal TotalSales { get; set; }
		// ProfitAmount
		public decimal ProfitAmount { get; set; }
		// ProfitPercent
		public decimal ProfitPercent { get; set; }
		// TotalSaleMaterial
		public decimal TotalSaleMaterial { get; set; }
		// TotalSaleLabor
		public decimal TotalSaleLabor { get; set; }
		public decimal TotalOverHead { get; set; }
	}
}
