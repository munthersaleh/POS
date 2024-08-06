using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class NotificationSent
	{
		public int? QuoteID { get; set; }
		public string ActionSource { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? HandledDate { get; set; }
		public string Notes { get; set; }
		public string EmployeeFullName { get; set; }
		public string ServiceTitle { get; set; }
		public bool IsContract { get; set; }
		public int? EmployeeID { get; set; }
		public int? CustomerID { get; set; }
		public string Action { get; set; }
		public int? HandledBy { get; set; }
		public int? PaymentMethodType { get; set; }
	}
}
