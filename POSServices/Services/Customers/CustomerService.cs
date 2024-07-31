using POSModel.Models;
using POSServices.Helpers;
using POSServices.HttpApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Customers
{
	public class CustomerService : ICustomerService
	{
		private readonly IApiManager _apiManager;

		public CustomerService(IApiManager apiManager)
		{
			_apiManager = apiManager;
		}

		public async Task<List<CustomerInfo>> GetAllCustomers()
		{
			try
			{
				var response = await _apiManager.GetAsync<List<CustomerInfo>>(AppConstants.baseAddress + "/customerfeature/GetCustomersBasicInfo");
				return response;
			}
			catch (Exception ex)
			{
				return null;
			}

		}

		public async Task<CustomerAddress> GetDefaultAddressByCustomerID(int customerId)
		{
			try
			{
				List<CustomerAddress> allAddress = await _apiManager.GetAsync<List<CustomerAddress>>(AppConstants.baseAddress + "/addressfeature/GetBasicAddressesByCustomerID?customerId=" + customerId);
				CustomerAddress defaultAddress = allAddress.Where(a => a.IsDefault == true).FirstOrDefault();
				return defaultAddress;
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
