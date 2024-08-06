using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class Profit
	{
		// TotalProfit
		public decimal Amount { get; set; }
		// ProfitPercent
		public decimal Percent { get; set; }
		public decimal TotalCost { get; set; }
	}
}
