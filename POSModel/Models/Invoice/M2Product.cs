using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class M2Product
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
		public int ProductID { get; set; }
		public string VendorTitle { get; set; }
		public string Style { get; set; }
		public string Color { get; set; }
		public string Description { get; set; }
		public decimal MeasurementSQFT { get; set; }
	}
}
