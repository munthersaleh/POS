using POSModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Customers
{
	public interface ICustomerService
	{
		Task<List<CustomerInfo>> GetAllCustomers();
		Task<CustomerAddress> GetDefaultAddressByCustomerID(int customerId);
	}
}
