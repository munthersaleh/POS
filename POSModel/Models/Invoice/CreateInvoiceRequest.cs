using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class CreateInvoiceRequest
	{
		public InvoiceResponse InvoiceData { get; set; }
		public InvoiceDetailRequest InvoiceDetail { get; set; }
	}
}
