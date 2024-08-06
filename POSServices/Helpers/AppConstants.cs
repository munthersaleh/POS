using POSModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Helpers
{
	public static class AppConstants
	{
        public static Uri baseAddress = new Uri("http://localhost/api");

		public static IEnumerable<SystemList> UOMList = new List<SystemList>();
		public static CompanySettings companySettings = new CompanySettings();
    }
}
