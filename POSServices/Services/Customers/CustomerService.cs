using POSModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Customers
{
	public class CustomerService : ICustomerService
	{
		public async Task<List<Customer>> GetAllCustomers()
		{
			List<Customer> customers = new List<Customer>
			{
				new Customer
				{
					CustomerId = 1,
					CustomerName = "John Doe",
					Phone = "(123) 456-7890",
					Email = "john.doe@example.com",
					Address = "123 Main St",
					City = "Anytown",
					Region = "State",
					PostalCode = "12345"
				},
				new Customer
				{
					CustomerId = 2,
					CustomerName = "Jane Smith",
					Phone = "(987) 654-3210",
					Email = "jane.smith@example.com",
					Address = "456 Elm St",
					City = "Another City",
					Region = "State",
					PostalCode = "67890"
				},
				new Customer
				{
					CustomerId = 3,
					CustomerName = "Michael Johnson",
					Phone = "(555) 555-5555",
					Email = "michael.johnson@example.com",
					Address = "789 Oak Ave",
					City = "Smalltown",
					Region = "State",
					PostalCode = "54321"
				},
				new Customer
				{
					CustomerId = 4,
					CustomerName = "Sarah Williams",
					Phone = "(222) 333-4444",
					Email = "sarah.williams@example.com",
					Address = "101 Pine Rd",
					City = "Villageville",
					Region = "State",
					PostalCode = "98765"
				},
				new Customer
				{
					CustomerId = 5,
					CustomerName = "Robert Brown",
					Phone = "(333) 444-5555",
					Email = "robert.brown@example.com",
					Address = "555 Cedar Blvd",
					City = "Townsville",
					Region = "State",
					PostalCode = "45678"
				},
				new Customer
				{
					CustomerId = 6,
					CustomerName = "Emily Davis",
					Phone = "(444) 555-6666",
					Email = "emily.davis@example.com",
					Address = "222 Maple Ln",
					City = "Metro City",
					Region = "State",
					PostalCode = "24680"
				},
				new Customer
				{
					CustomerId = 7,
					CustomerName = "James Wilson",
					Phone = "(666) 777-8888",
					Email = "james.wilson@example.com",
					Address = "777 Beach Dr",
					City = "Coastal City",
					Region = "State",
					PostalCode = "13579"
				},
				new Customer
				{
					CustomerId = 8,
					CustomerName = "Amanda Martinez",
					Phone = "(777) 888-9999",
					Email = "amanda.martinez@example.com",
					Address = "888 Sunset Ave",
					City = "Mountain View",
					Region = "State",
					PostalCode = "80234"
				},
				new Customer
				{
					CustomerId = 9,
					CustomerName = "Daniel Miller",
					Phone = "(888) 999-0000",
					Email = "daniel.miller@example.com",
					Address = "333 Hillside Rd",
					City = "Hilltown",
					Region = "State",
					PostalCode = "97531"
				},
				new Customer
				{
					CustomerId = 10,
					CustomerName = "Olivia Moore",
					Phone = "(999) 000-1111",
					Email = "olivia.moore@example.com",
					Address = "444 River Blvd",
					City = "Riverside",
					Region = "State",
					PostalCode = "64203"
				},

			};
			return customers;
		}
	}
}
