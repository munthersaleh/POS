using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models 
{
	public class MaterialRestockData
	{
		public string FeeType { get; set; }
		public decimal VoidFees { get; set; }
		public decimal BeforeVoidFee { get; set; }
		public string OrderNumber { get; set; }
	}
}
