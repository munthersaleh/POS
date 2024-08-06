using POSModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Invoices
{
	public interface IInvoiceService
	{
		Task<CreateInvoiceRequest> CreateInvoiceObject();
		Task<CreateInvoiceRequest> CreateInvoice(CreateInvoiceRequest invoice);
	}
}
