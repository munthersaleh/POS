using POSModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models 
{
	public class QuoteDetailsRequest
	{
		public int InvoiceTypeID { get; set; }
		public int? EmployeeTaskID { get; set; }
		public int? EmployeeID { get; set; }
		public int AddressID { get; set; }
		public decimal? TaxRate { get; set; }
		public DateTime? QuoteInvoiceCreatedDate { get; set; }
		public DateTime? QuoteInvoiceOriginalCreatedDate { get; set; }
		public decimal? PSTTaxRate { get; set; }
		public int? FloorID { get; set; }
		public string Unit { get; set; }
		public string ModelBoxes { get; set; }
		public int? BillingContactID { get; set; }
		public BillingContactTypeEnum? BillingContactType { get; set; }
		public int QuoteID { get; set; }
		public string QuoteNumber { get; set; }
		public int LocationID { get; set; }
		public int CustomerID { get; set; }
		public short QuoteStatus { get; set; }
		public DateTime CreatedDate { get; set; }
		public int CreatedBy { get; set; }
		public string CustomerContactID { get; set; }
		public DateTime? ExpirationDate { get; set; }
		public string QuoteInvoiceName { get; set; }
		public int MarginCalculateType { get; set; }
		public int ServiceSiteContactID { get; set; }
		public bool? UseQuoteNameAsPONo { get; set; }
		public bool TaxCalculationAfterDiscount { get; set; }
		public int TaxSource { get; set; }
		public Customer Customer { get; set; }
		public int? ClassID { get; set; }
		public int? PSTTaxSource { get; set; }
		public string PONumber { get; set; }
		public DateTime? OriginalCreatedDate { get; set; }
		public MaterialOnly MaterialOnly { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public bool? ShowUnitPriceInCustomerQuote { get; set; }
		public bool? ShowQuantityInCustomerQuote { get; set; }
		public bool? ShowTaxesInCustomerQuote { get; set; }
		public bool ShowItemName { get; set; }
		public bool? ShowAmountInCustomerQuote { get; set; }
		public bool? ShowAmountGroupByService { get; set; }
		public bool? ShowQuantityUOM { get; set; }
		public bool ShowApproveButton { get; set; }
		public bool? ShowServiceType { get; set; }
		public string ProjectQBReferenceID { get; set; }
		public RepairInspection RepairInspection { get; set; }
		public List<Salesman> Salesmans { get; set; }
		public int PaymentTermID { get; set; }
		public bool SalesTaxAsCost { get; set; }
		public decimal MaterialOverheadPercentage { get; set; }
		public decimal LaborOverheadPercentage { get; set; }
		public decimal SubTotalOverheadPercentage { get; set; }
		public bool ApplyMaterialOverheadToSellPrice { get; set; }
		public bool ApplyLaborOverheadToSellPrice { get; set; }
		public int DiscountApply { get; set; }
		public int CommissionType { get; set; }
		public int NetSales { get; set; }
		public int NetCost { get; set; }
		public int InvoiceCategory { get; set; }
	}
}
