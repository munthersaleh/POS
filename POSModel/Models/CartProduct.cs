using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class CartProduct
	{
		public int ProductId { get; set; }
		public string ItemCode { get; set; }
		public string Name { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal Discount { get; set; } = 0;
		public bool IsSaleTax { get; set; } = true;
		public int Quantity { get; set; }
		public string Sku { get; set; }

		public bool IsStock {  get; set; }
	}
}
