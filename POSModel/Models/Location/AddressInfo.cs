using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class AddressInfo
	{
		public int AddressID { get; set; }
		public bool IsBillingAddress { get; set; }
		public bool IsShippingAddress { get; set; }
		public string StreetNumber { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public DateTime CreatedDate { get; set; }
		public int CreatedBy { get; set; }
		public bool Active { get; set; }
		public bool Deleted { get; set; }
		public string Zip2 { get; set; }
		public string AddressURL { get; set; }
		public string Country { get; set; }
		public string County { get; set; }
		public string AddressLat { get; set; }
		public string AddressLang { get; set; }
		public string Neighborhood { get; set; }
		public string StreetAddress { get; set; }
		public string AddressTitle { get; set; }
		public string FullAddress
		{
			get
			{
				string fullAddress = string.Empty;

				if (!string.IsNullOrEmpty(StreetNumber))
				{
					fullAddress += StreetNumber + " ";
				}

				if (!string.IsNullOrEmpty(Address1))
				{
					fullAddress += Address1 + ", ";
				}

				if (!string.IsNullOrEmpty(Address2))
				{
					fullAddress += Address2 + ", ";
				}

				if (!string.IsNullOrEmpty(City))
				{
					fullAddress += City + ", ";
				}

				if (!string.IsNullOrEmpty(State))
				{
					fullAddress += State;
				}

				if (!string.IsNullOrEmpty(Zip))
				{
					fullAddress += " " + Zip;
				}

				return fullAddress;
			}
		}
	}
}
