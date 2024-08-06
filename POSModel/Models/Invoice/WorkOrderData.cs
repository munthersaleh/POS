using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class WorkOrderData
	{
		public decimal ExtraCardFeesFromViewInvoice { get; set; }
		public string InvoiceNumber { get; set; }
		public int InvoiceSalesHistoryCount { get; set; }
		public int TaxJournalID { get; set; }
		public bool MarkAsFinalInvoice { get; set; }
		public bool IsMaterialBalance { get; set; }
		public DateTime InvoiceOriginalCreatedDate { get; set; }
		public DateTime SignedDate { get; set; }
		public DateTime InvoiceResetDate { get; set; }
	}
}
