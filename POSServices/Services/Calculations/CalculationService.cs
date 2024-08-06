using POSModel.Models;
using POSServices.Helpers;
using POSServices.HttpApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Calculations
{
    public class CalculationService : ICalculationService
    {
        private readonly IApiManager _apiManager;

        public CalculationService(IApiManager apiManager)
        {
            _apiManager = apiManager;
        }
        public async Task<InvoiceResponse> AddMultipleLineItems(InvoiceResponse invoiceData)
        {
            try
            {
                var response = await _apiManager.PostAsync<InvoiceResponse>(AppConstants.baseAddress + "/calculatefeature/AddMultipleLineItems", invoiceData);
                return response;
            }
            catch (Exception ex)
            {
                return new InvoiceResponse();
            }
        }

        public async Task<InvoiceResponse> UpdateLineItem(InvoiceResponse invoiceData)
        {
            try
            {
                var response = await _apiManager.PostAsync<InvoiceResponse>(AppConstants.baseAddress + "/calculatefeature/UpdateLineItem", invoiceData);
                return response;
            }
            catch (Exception ex)
            {
                return new InvoiceResponse();
            }
        }

        public async Task<InvoiceResponse> DeleteLineItem(InvoiceResponse invoiceData)
        {
            try
            {
                var response = await _apiManager.PostAsync<InvoiceResponse>(AppConstants.baseAddress + "/calculatefeature/DeleteLineItem", invoiceData);
                return response;
            }
            catch (Exception ex)
            {
                return new InvoiceResponse();
            }
        }
    }
}
