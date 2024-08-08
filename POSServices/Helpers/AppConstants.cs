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
        public static Uri baseAddress = new Uri("https://develop.fzbms.com/api");
        public static string apiCookies = "ASP.NET_SessionId=zryit5j5edr0i02nni2hcb33; FloorzapAuthCookie=4qvrlvdcGseHHPLuGaySSVRzIIKAczXSaJ_N6_BzfBjIH6CNgwLxLjmgYkypDU7A6cUgty3x4K6iYKEf5V6a963hjiO-ZBO8rg0HKdoAYbcrJBizqUiOnzyOoE7Rn0Y8YT6cc6IbG6RRm1Je_aX_peLdR67Ejt8nwwlokpYDKN_EPvOWOA0Xf7kEd_qvlji583jybOVxhy5hMl693LNKbuiLxEr-FqyKBSBP__6Mj3jgF6J3DOoyTK5blVSOqsFj4Mya9A92OV1l6rHhQm2hjnklVKyqoHBjDjlq_H9zmQn6dJWeavlUV_W3GDTkIcDLebZsbpAw69hOUUye65R6-F5g9oJH1YdbPSQd29M2HFAq5CoZZ9ngp4XQvjrmP5HSJ6wS3EkiW7L43xBNBVtUcUL9OYQTyScBUnKKoFh0iDukg2rLo-r-HKPq8KNBC4D0GdCBYA3muDZcs1nsboEyQlNYphTmiNMUJUGiEtRxtt_VObsCksDHr2EwwVv7oIjYVQzW8ILIxQfTmqyikJDLbQ";

        public static IEnumerable<SystemList> allSystemLists = new List<SystemList>();
		public static CompanySettings companySettings = new CompanySettings();
    }
}
