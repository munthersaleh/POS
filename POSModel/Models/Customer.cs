using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class Customer
	{
		public int CustomerID { get; set; }
		public string Email { get; set; }
		public string FullName { get; set; }
		public string CellPhone { get; set; }
		public string CompanyName { get; set; }
		public bool LeadStatus { get; set; }
		public int LocationID { get; set; }
		public string FirstName { get; set; }
		public string CCEmail { get; set; }
		public int UserReferral { get; set; }
		public int CustomerReferral { get; set; }
	}
}
