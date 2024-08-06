using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class Total
	{
		// SubTotal
		public decimal SubTotal { get; set; }
		// TotalTax
		public decimal SalesTax { get; set; }
		// TotalUseTax
		public decimal UseTax { get; set; }
		// TotalPSTTax
		public decimal PSTTax { get; set; }
		// TaxRate
		public decimal SalesTaxPercent { get; set; }
		// TotalSale
		public decimal TotalSale { get; set; }
		// TotalCost
		public decimal TotalCost { get; set; }
		// ServiceTypesTotal
		public decimal ServiceTypesTotal { get; set; }
		// ServiceTypesSalesTax
		public decimal ServiceTypesSalesTax { get; set; }
		public decimal ServiceTypesPSTTax { get; set; }
		// TotalQuoteInvoiceMaterialTax
		public decimal MaterialTax { get; set; }
		// TotalFreightAmount
		public decimal Freight { get; set; }
		public decimal TotalOverHead { get; set; }
	}
}
