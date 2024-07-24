using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class Product
	{
		public int ProductId {  get; set; }

		public string ItemCode { get; set; }

		public string Name { get; set; }
		public decimal UnitPrice { get; set; }
		public int AvailableStock { get; set; }
		public string Sku { get; set; }

	}
}
