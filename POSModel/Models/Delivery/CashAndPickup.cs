using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class CashAndPickup
	{
		public string Notes { get; set; }
		public DateTime? PickUpDate { get; set; }
		public int? LocationID { get; set; }
	}
}
