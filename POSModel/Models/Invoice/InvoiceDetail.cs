using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class InvoiceDetail
	{
		public int QuoteID { get; set; }
		public int InvoiceTypeID { get; set; }
		public int InvoiceDetailID { get; set; }
		public string Notes { get; set; }
		public int LocationID { get; set; }
		public int AddressID { get; set; }
		public byte MaterialOnlyType { get; set; }
		public DateTime? ActionDate { get; set; }
		public string CreatedBy { get; set; }
		public LocationInfo Location { get; set; }
		public AddressInfo Address { get; set; }
	}
}
