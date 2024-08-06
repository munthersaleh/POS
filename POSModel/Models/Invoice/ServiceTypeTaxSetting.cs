using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class ServiceTypeTaxSetting
	{
		public int SystemListID { get; set; }
		public string Title { get; set; }
		public int ServiceTypeTaxSettingID { get; set; }
		public bool? MaterialAndLaborUseTax { get; set; }
		public bool? MaterialOnlyUseTax { get; set; }
		public bool? EnableSalesTax { get; set; }
	}
}
