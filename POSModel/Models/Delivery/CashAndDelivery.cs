using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models 
{
	public class CashAndDelivery
	{
		public DateTime? DeliveryDateTime { get; set; }
		public int? AddressID { get; set; }
		public string Notes { get; set; }
	}
}
