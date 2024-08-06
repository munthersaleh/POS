using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models 
{
	public class RepairInspection
	{
		public int RepairInspectionID { get; set; }
		public DateTime? InspectionDate { get; set; }
		public int InspectionBy { get; set; }
		public string InspectionNotes { get; set; }
		public int InvoiceID { get; set; }
		public int? EmployeeTaskID { get; set; }
		public int? NewQuoteID { get; set; }
		public string QuoteInvoiceNumber { get; set; }
	}
}
