using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class CommissionSetting
	{
		public int CommissionID { get; set; }
		public byte BasedOn { get; set; }
		public byte Per { get; set; }
		public int Selection { get; set; }
		public decimal Value1 { get; set; }
		public decimal Value2 { get; set; }
		public string ValuesOperation { get; set; }
		public byte CommissionValueType { get; set; }
		public decimal CommissionValue { get; set; }
		public string CommissionValueOperation { get; set; }
		public int SystemListID { get; set; }
		public int UserID { get; set; }
	}
}
