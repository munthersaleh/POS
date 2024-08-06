using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class InvoiceDetailRequest : QuoteDetailsRequest
	{
		public int PaymentTermID { get; set; }
		public DateTime? InvoiceDate { get; set; }
		public bool ApplyCreditCardFees { get; set; }
	}
}
