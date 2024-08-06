using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class LIPricingDetails
	{
		// UnitCost
		public decimal UnitCost { get; set; }
		// Quantity
		public decimal Quantity { get; set; }
		// SQF
		public decimal TotalSQF { get; set; }

		private decimal _totalCost;
		// TotalCost
		public decimal TotalCost
		{
			get { return _totalCost; }
			set
			{
				_totalCost = value;
				NetCost = _totalCost;
			}
		}
		// ProfitMargin
		public decimal Margin { get; set; }
		// SellingPrice
		public decimal UnitPrice { get; set; }

		private decimal _totalPrice;
		// SalesPrice
		public decimal TotalPrice
		{
			get
			{
				return _totalPrice;
			}
			set
			{
				_totalPrice = value;
				NetSales = _totalPrice;
			}
		}
		// IsTaxable
		public bool IsTaxable { get; set; }
		// IsPSTTaxable
		public bool IsPSTTaxable { get; set; }
		public string PropertyName { get; set; }
		public decimal PropertyValue { get; set; }
		public decimal Overhead { get; set; }
		public decimal NetSales { get; set; }
		public decimal NetCost { get; set; }
	}
}
