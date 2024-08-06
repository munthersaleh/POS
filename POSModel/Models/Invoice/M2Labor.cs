using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class M2Labor
	{
		public int MeasurementID { get; set; }
		public string AreaText { get; set; }
		public int JobTypeID { get; set; }
		public int CurrentServiceTypeID { get; set; }
		public string M2ProductName { get; set; }
		public decimal M2CostPrice { get; set; }
		public decimal M2MarginPercentage { get; set; }
		public string M2Unit { get; set; }
		public bool M2IsLabor { get; set; }
		public int LaborCostID { get; set; }
		public decimal Price { get; set; }
		public string Title { get; set; }
		public int MeasurementUnitID { get; set; }
		public decimal MeasurementSQFT { get; set; }
	}
}
