using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class Measurement
	{
		public int MeasurementID { get; set; }
		public int JobTypeID { get; set; }
		public string JobTypeTitle { get; set; }
		public int EmployeeTaskID { get; set; }
		public int CurrentServiceTypeID { get; set; }
		public string Special { get; set; }
		public string Title { get; set; }
		public decimal Sqft { get; set; }
		public decimal Waste { get; set; }
		public decimal Quantity { get; set; }
		public int SystemListID { get; set; }
		public string FloorLevelTitle { get; set; }
		public decimal? StairNose { get; set; }
		public string Comments { get; set; }
	}
}
