using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class InvoicePaidAmount
	{
		public decimal InvoiceAmount { get; set; }
		public decimal AmountPaid { get; set; }
		public decimal CustomerAdjustments { get; set; }
		public decimal AmountDue { get; set; }
	}
}
