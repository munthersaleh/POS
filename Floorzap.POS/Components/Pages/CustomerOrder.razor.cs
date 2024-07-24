using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Drawing.Printing;
using POSModel.Models;
using Microsoft.AspNetCore.Components;
using POSServices.Services.Products;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using POSServices.Services.Customers;

namespace Floorzap.POS.Components.Pages
{
	public partial class CustomerOrder
	{ 
	
		List<Product> allProducts = new List<Product>();
		List<Customer> allCustomers = new List<Customer>();
		List<Customer> filteredCustomers = new List<Customer>();
		List<CartProduct> cartProducts = new List<CartProduct>();

		List<Product> filteredProducts = new List<Product>();

		Customer selectedCustomer;
		int selectedCustomerId = -1;
		decimal subTotal = 0;
		decimal taxPrice = 0;
		decimal totalPrice = 0;
		string searchTerm = string.Empty;
		string searchCustomer = string.Empty;

		[Inject]
		IProductService productService { get; set; }

		[Inject]
		ICustomerService customerService { get; set; }

		[Inject]
		IJSRuntime JSRuntime { get; set; }

		private bool isShownCustomerList = false;

		protected override async Task OnInitializedAsync()
		{
			allProducts = await productService.GetAllProducts();
		}
		public void HandleSearchInput(ChangeEventArgs args)
		{
			searchTerm = args.Value.ToString();

			if (!string.IsNullOrEmpty(searchTerm))
			{
				filteredProducts = allProducts
					.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || p.ItemCode.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).Take(10)
					.ToList();
			}
			else
			{
				filteredProducts.Clear();
			}
		}
	

		private async Task HandleAddToCart(KeyboardEventArgs e, Product product)
		{
			if (e.Key == "Enter")
			{
				await AddToCart(product);
			}
		}

		private async Task AddToCart(Product product)
		{
			var productToAdd = cartProducts.FirstOrDefault(p => p.ProductId == product.ProductId);
			if (productToAdd == null)
			{
				cartProducts.Add(new CartProduct
				{
					ProductId = product.ProductId,
					Name = product.Name,
					Sku = product.Sku,
					Quantity = 1,
					UnitPrice = product.UnitPrice,
					ItemCode = product.ItemCode,
					IsSaleTax = true
				});
			}
			else
			{
				productToAdd.Quantity++;
			}
			CalculateCartItemsPrice();

			//delay is added so the element can render to get focus
			await InvokeAsync(async () =>
			{
				await Task.Delay(50);
				await FocusElementById(product.ProductId);
			});
			searchTerm = string.Empty;
			filteredProducts.Clear();
		}

		private async Task FocusElementById(int productId)
		{
			await JSRuntime.InvokeVoidAsync("focusElementById", $"cartItemQuantity_{productId}");
		}
		private void CalculateCartItemsPrice()
		{
			subTotal = 0;
			taxPrice = 0;
			foreach(var item in cartProducts)
			{
				decimal itemTotalPrice = (item.UnitPrice * item.Quantity) - item.Discount;
				subTotal += itemTotalPrice;

				if (item.IsSaleTax) {
					taxPrice += itemTotalPrice * (0.06m);
				 }
			}
			taxPrice = Math.Round(taxPrice, 2);
			totalPrice = Math.Round(subTotal + taxPrice, 2);
		}
		private void UpdateCartProduct()
		{
			CalculateCartItemsPrice();
		}

		private void RemoveCartProduct(int cartProductId)
		{
			var productToRemove = cartProducts.FirstOrDefault(p => p.ProductId == cartProductId);
			if (productToRemove != null)
			{
				cartProducts.Remove(productToRemove);
			}
			CalculateCartItemsPrice();
		}

	
		private async void GetAllCustomers()
		{
			if (string.IsNullOrEmpty(searchCustomer))
			{
				allCustomers = await customerService.GetAllCustomers();
				filteredCustomers = allCustomers;
			}
			else
			{
				filteredCustomers = allCustomers
					.Where(p => p.CustomerName.Contains(searchCustomer, StringComparison.OrdinalIgnoreCase))
					.ToList();
		    }
			isShownCustomerList = true;
		}
		private void ChangeCustomer(Customer customer)
		{
			selectedCustomer = customer;
			searchCustomer = customer.CustomerName;
			isShownCustomerList = false;

		}
		 
		public void HandleCustomerSearchInput(ChangeEventArgs args)
		{
			searchCustomer = args.Value.ToString();

			if (!string.IsNullOrEmpty(searchCustomer))
			{
				filteredCustomers = allCustomers
					.Where(p => p.CustomerName.Contains(searchCustomer, StringComparison.OrdinalIgnoreCase))
					.ToList();
			}
			else
			{
				filteredCustomers = allCustomers;
			}
		}
	}
}
