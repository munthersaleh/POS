using POSModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Calculations
{
    public interface ICalculationService
    {
        public Task<InvoiceResponse> AddMultipleLineItems(InvoiceResponse invoice);
        public Task<InvoiceResponse> UpdateLineItem(InvoiceResponse invoice);
        public Task<InvoiceResponse> DeleteLineItem(InvoiceResponse invoice);
    }
}
