using POSModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class Discount
	{
		public int QuoteID { get; set; }
		// DiscountAmount
		public decimal Amount { get; set; }
		public decimal SalesTaxAmount { get; set; }
		public decimal PSTTaxAmount { get; set; }
		// Discount
		public decimal Value { get; set; }
		// DiscountType
		public DiscountTypeEnum Type { get; set; } = DiscountTypeEnum.Dollar;
		// DiscountComment
		public string Notes { get; set; } = string.Empty;
		public decimal LineItemTotal { get; set; }
	}
}
