using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class CustomerInfo
	{
		public int CustomerID { get; set; }
		public string FullName { get; set; }
		public int LocationID { get; set; }
		public bool TaxExempt { get; set; }

	}
}
