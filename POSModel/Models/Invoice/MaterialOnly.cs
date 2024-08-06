using POSModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class MaterialOnly
	{
		public int? InvoiceDetailID { get; set; }
		public int? QuoteID { get; set; }
		public int? InvoiceID { get; set; }
		public CashAndDelivery CashAndDelivery { get; set; }
		public CashAndPickup CashAndPickup { get; set; }

		public static explicit operator MaterialOnly(InvoiceDetail v)
		{
			MaterialOnly mat = new MaterialOnly();
			if (v != null)
			{
				mat.InvoiceDetailID = v.InvoiceDetailID;
				if (v.MaterialOnlyType == (int)MaterialOnlyEnum.CashAndDelivery)
				{
					mat.CashAndDelivery = new CashAndDelivery
					{
						AddressID = v.AddressID,
						DeliveryDateTime = v.ActionDate,
						Notes = v.Notes
					};
				}
				else if (v.MaterialOnlyType == (int)MaterialOnlyEnum.CashAndPickup)
				{
					mat.CashAndPickup = new CashAndPickup
					{
						LocationID = v.LocationID,
						Notes = v.Notes,
						PickUpDate = v.ActionDate
					};
				}
			}

			return mat;
		}
	}
}
