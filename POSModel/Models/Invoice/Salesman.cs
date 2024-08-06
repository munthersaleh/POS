using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class Salesman
	{
		public int InvoiceSalesmanID { get; set; }
		public int QuoteID { get; set; }
		public int InvoiceID { get; set; }
		public int SalesmanID { get; set; }
		public decimal CommissionValue { get; set; }
		public int CommissionValueType { get; set; }
		public decimal Amount { get; set; }
		public decimal Balance { get; set; }
		public decimal AmountToPay { get; set; }
		public int PaidStatus { get; set; }
		public string FullName { get; set; }
		public int CreatedBy { get; set; }
	}
}
