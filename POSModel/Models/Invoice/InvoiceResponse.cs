using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class InvoiceResponse : QuoteResponse
	{
		public int InvoiceID { get; set; }
		public string InvoiceNumber { get; set; }
		public string CustomerSignature { get; set; }
		public WorkOrderData WorkOrderData { get; set; }
		public List<MaterialRestockData> MaterialRestockData { get; set; }
		public int CreatedBy { get; set; }
		public string TaxText { get; set; }
		public string AdjustmentText { get; set; }
		public bool? ShowPaymentMethod { get; set; }
		public bool ApplyCreditCardFees { get; set; }
		public DateTime? SignedDate { get; set; }
		public DateTime? InvoiceResetDate { get; set; }
	}
}
