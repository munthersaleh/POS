using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models 
{
	public class ServiceTypeDetails
	{
		public ServiceTypeDetails()
		{
			ServiceTypePricingDetails = new ServiceTypePricingDetails();
		}
		public ServiceTypePricingDetails ServiceTypePricingDetails { get; set; }
		public bool? MaterialAndLaborUseTax { get; set; }
		public bool? MaterialOnlyUseTax { get; set; }
		public bool? EnableSalesTax { get; set; }
	}
}
