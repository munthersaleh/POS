using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class LocationInfo
	{
		public int LocationID { get; set; }
		public string Title { get; set; }
		public bool? UseForBranding { get; set; }
		public string BrandLogo { get; set; }
		public string StreetNumber { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Zip2 { get; set; }
		public string PhoneNumber { get; set; }
		public string FaxNumber { get; set; }
		public string Website { get; set; }
		public string FullAddress { get; set; }
		public bool IsBritishColumbiaPST { get; set; }
		public string Email { get; set; }
		public string Logo { get; set; }
	}
}
