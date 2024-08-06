using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class Employee
	{
		public int EmployeeID { get; set; }
		public string FullName { get; set; }
		public int CommissionTypeID { get; set; }
		public IEnumerable<CommissionSetting> Commission { get; set; }
	}
}
