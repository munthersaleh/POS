using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using POSModel.Models;
using POSServices.Services.Customers;
using POSServices.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floorzap.POS.Components.Pages
{
	public partial class ProductOrder
	{

        private string cashPayment = "selected-payment";
        private string cardPayment = "unselected-payment";

        List<Product> allProducts = new List<Product>();
        List<CustomerInfo> allCustomers = new List<CustomerInfo>();
        List<CustomerInfo> filteredCustomers = new List<CustomerInfo>();
        List<CartProduct> cartProducts = new List<CartProduct>();

        List<Product> filteredProducts = new List<Product>();

		CustomerInfo selectedCustomer;
        CustomerAddress customerAddress = new CustomerAddress();

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
        [Inject]
        NavigationManager navigationManager { get; set; }

        private bool isShownCustomerList = false;

        protected override async Task OnInitializedAsync()
        {
            allProducts = await productService.GetAllInventoryProducts();
			allCustomers = await customerService.GetAllCustomers();

		}
		public void HandleSearchInput(ChangeEventArgs args)
        {
            searchTerm = args.Value.ToString();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                filteredProducts = allProducts
                    .Where(p => p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || p.SKU.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).Take(10)
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
            var productToAdd = cartProducts.FirstOrDefault(p => p.ProductId == product.ProductID);
            if (productToAdd == null)
            {
                cartProducts.Add(new CartProduct
                {
                    ProductId = product.ProductID,
                    Name = product.Description,
                    Sku = product.SKU,
                    Quantity = 1,
                    UnitPrice = product.RegularPrice,
                    ItemCode = product.SKU,
                    IsSaleTax = true,
                    IsStock = product.IsStock
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
                await FocusElementById(product.ProductID);
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
            foreach (var item in cartProducts)
            {
                decimal itemTotalPrice = (item.UnitPrice * item.Quantity) - item.Discount;
                subTotal += itemTotalPrice;

                if (item.IsSaleTax)
                {
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
				filteredCustomers = allCustomers;
            }
            else
            {
                filteredCustomers = allCustomers
                    .Where(p => p.FullName.Contains(searchCustomer, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            isShownCustomerList = true;
        }
        private async Task ChangeCustomer(CustomerInfo customer)
        {
            selectedCustomer = customer;
            searchCustomer = customer.FullName;
            isShownCustomerList = false;
            customerAddress = await customerService.GetDefaultAddressByCustomerID(customer.CustomerID);

        }

        public void HandleCustomerSearchInput(ChangeEventArgs args)
        {
            searchCustomer = args.Value.ToString();

            if (!string.IsNullOrEmpty(searchCustomer))
            {
                filteredCustomers = allCustomers
                    .Where(p => p.FullName.Contains(searchCustomer, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            else
            {
                filteredCustomers = allCustomers;
            }
        }
        private void LogOut()
        {
            navigationManager.NavigateTo("/");
        }
        private void ChangePaymentMethod(bool isCashMethod)
        {
            if (isCashMethod)
            {
                cashPayment = "selected-payment";
                cardPayment = "unselected-payment";
            }
            else
            {
                cashPayment = "unselected-payment";
                cardPayment = "selected-payment";
            }
        }

        private async Task AddCartsItems(HashSet<Product> products)
        {
			var newCartProducts = products.Select(pro => MapToCartProduct(pro)).ToList();

			// Get existing product IDs in the cart
			var existingProductIds = new HashSet<int>(cartProducts.Select(cp => cp.ProductId));

			// Filter out products that are already in the cart
			var productsToAdd = newCartProducts
				.Where(cp => !existingProductIds.Contains(cp.ProductId))
				.ToList();

			// Add only new products to the cart
			cartProducts.AddRange(productsToAdd);
            CalculateCartItemsPrice();

        }
		private CartProduct MapToCartProduct(Product product)
		{
			return new CartProduct
			{
				ProductId = product.ProductID,
				Name = product.ProductName,
				Sku = product.SKU,
				Quantity = 1,
				UnitPrice = product.UnitCost,
				ItemCode = product.SKU,
				IsSaleTax = true,
                IsStock = product.IsStock
			};
		}

	}


}
