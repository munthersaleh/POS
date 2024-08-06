using POSModel.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
	public class QuoteResponse : QuoteDetails
	{
		public QuoteResponse()
		{
			ServiceTypes = new List<ServiceTypeItem>();
			Salesman = new List<Salesman>();
		}
		public DateTime CreatedDate { get; set; }
		public string CreatedByName { get; set; }
		public string CustomMessage { get; set; }
		public short QuoteStatus { get; set; }
		public int QuoteID { get; set; }
		public int OriginalQuoteID { get; set; }
		public string QuoteNumber { get; set; }
		public int Type { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string QuoteInvoiceName { get; set; }
		public int AddressID { get; set; }
		public int CustomerID { get; set; }
		public string CustomerContactID { get; set; }
		public int LocationID { get; set; }
		public string VoidReason { get; set; }
		public bool? ShowUnitPriceInCustomerQuote { get; set; }
		public bool? ShowQuantityInCustomerQuote { get; set; }
		public bool? ShowTaxesInCustomerQuote { get; set; }
		public bool ShowItemName { get; set; }
		public bool? ShowAmountInCustomerQuote { get; set; }
		public bool? ShowAmountGroupByService { get; set; }
		public bool? ShowQuantityUOM { get; set; }
		public bool ShowApproveButton { get; set; }
		public decimal? MaterialTaxRate { get; set; }
		public string PSTText { get; set; }
		public bool? ShowServiceType { get; set; }
		public string OtherTaxDetails { get; set; }
		public int TaxSource { get; set; }
		public int PSTTaxSource { get; set; }
		public bool IsMaterialBalance { get; set; }
		public bool IsCustomPercent { get; set; }
		public int QuoteInvoiceStatus { get; set; }
		public MaterialOnly MaterialOnly { get; set; }
		public Customer Customer { get; set; }
		public ContactInfo ContactInfo { get; set; }
		public RepairInspection RepairInspection { get; set; }
		public List<ServiceTypeItem> ServiceTypes { get; set; }
		public Employee Employee { get; set; }
		public List<Salesman> Salesman { get; set; }
		public IEnumerable<NotificationSent> Notifications { get; set; }
		public QuoteActionEnum Action { get; set; }
		public int? EmployeeTaskID { get; set; }
		public IEnumerable<Measurement> Measurements { get; set; }
		public IEnumerable<M2Product> M2Products { get; set; }
		public IEnumerable<M2Labor> M2Labors { get; set; }
		public string DeadReason { get; set; }
		public bool IsCalculated { get; set; }
		public int InvoiceCategory { get; set; }
		public decimal NetProfit
		{
			get
			{
				return QuoteProfit.Amount - QuoteCommission.Amount;
			}
		}
		public decimal NetProfitPercentage
		{
			get
			{
				return Math.Round(QuoteProfit.Amount > 0 && QuoteProfit.Percent > 0 ? NetProfit / (QuoteProfit.Amount / QuoteProfit.Percent) : 0);
			}
		}
		public DateTime? ExpirationDate { get; set; }
	}
}
