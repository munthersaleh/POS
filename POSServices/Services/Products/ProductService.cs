using POSModel.Models;
using POSServices.Helpers;
using POSServices.HttpApiManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Products
{
	public class ProductService : IProductService
	{

		private readonly IApiManager _apiManager;

		public ProductService(IApiManager apiManager)
		{
			_apiManager = apiManager;
		}

		public async Task<List<Product>> GetAllInventoryProducts()
        {
            List<Product> productList = await GetAllProducts();
            int i = 10001;
            int j = 2;
            foreach (var product in productList)
            {
                product.ProductID = j;
                product.SKU = i.ToString();
                product.IsStock = true;
                i += 2;
                j += 2;
            }

            return productList;
        }

        public async Task<List<Product>> GetAllNonInventoryProducts()
        {
            List<Product> productList = await GetAllProducts();
            int i = 10000;
            int j = 1;
            foreach (var product in productList)
            {
                product.ProductID = j;
                product.SKU = i.ToString();
                product.IsStock = false;
                i += 2;
                j += 2;
            }

            return productList;
        }

        public async Task<List<Product>> GetAllProducts()
        {

            return new List<Product>
             {
            new Product { ProductID = 1, ActualProductName = "Gaming Laptop", RegularPrice = 1299.99m, AvailableQuantity = 50, SKU = "GLP001" },
            new Product { ProductID = 2, ActualProductName = "Smartphone", RegularPrice = 699.99m, AvailableQuantity = 100, SKU = "SPH002" },
            new Product { ProductID = 3, ActualProductName = "Bluetooth Headphones", RegularPrice = 149.99m, AvailableQuantity = 150, SKU = "BHP003" },
            new Product { ProductID = 4, ActualProductName = "4K Smart TV", RegularPrice = 899.99m, AvailableQuantity = 30, SKU = "TV004" },
            new Product { ProductID = 5, ActualProductName = "Fitness Tracker", RegularPrice = 79.99m, AvailableQuantity = 200, SKU = "FT005" },
            new Product { ProductID = 6, ActualProductName = "External Hard Drive", RegularPrice = 129.99m, AvailableQuantity = 80, SKU = "EHD006" },
            new Product { ProductID = 7, ActualProductName = "Wireless Keyboard", RegularPrice = 59.99m, AvailableQuantity = 120, SKU = "WKM007" },
            new Product { ProductID = 8, ActualProductName = "Coffee Maker", RegularPrice = 49.99m, AvailableQuantity = 180, SKU = "CM008" },
            new Product { ProductID = 9, ActualProductName = "Bluetooth Speaker", RegularPrice = 89.99m, AvailableQuantity = 90, SKU = "BSP009" },
            new Product { ProductID = 10, ActualProductName = "Electric Toothbrush", RegularPrice = 39.99m, AvailableQuantity = 150, SKU = "ETB010" },
            new Product { ProductID = 11, ActualProductName = "Air Fryer", RegularPrice = 129.99m, AvailableQuantity = 60, SKU = "AF011" },
            new Product { ProductID = 12, ActualProductName = "Robot Vacuum", RegularPrice = 299.99m, AvailableQuantity = 40, SKU = "RVC012" },
            new Product { ProductID = 13, ActualProductName = "Portable Power Bank", RegularPrice = 29.99m, AvailableQuantity = 250, SKU = "PPB013" },
            new Product { ProductID = 14, ActualProductName = "Monitor Stand", RegularPrice = 49.99m, AvailableQuantity = 100, SKU = "MS014" },
            new Product { ProductID = 15, ActualProductName = "Wireless Earbuds", RegularPrice = 129.99m, AvailableQuantity = 70, SKU = "WEB015" },
            new Product { ProductID = 16, ActualProductName = "Backpack", RegularPrice = 79.99m, AvailableQuantity = 120, SKU = "BP016" },
            new Product { ProductID = 17, ActualProductName = "Smart Watch", RegularPrice = 199.99m, AvailableQuantity = 80, SKU = "SW017" },
            new Product { ProductID = 18, ActualProductName = "Desktop Computer", RegularPrice = 1499.99m, AvailableQuantity = 30, SKU = "DC018" },
            new Product { ProductID = 19, ActualProductName = "Portable Bluetooth", RegularPrice = 199.99m, AvailableQuantity = 50, SKU = "PBP019" },
            new Product { ProductID = 20, ActualProductName = "Electric Scooter", RegularPrice = 399.99m, AvailableQuantity = 25, SKU = "ES020" },
            new Product { ProductID = 21, ActualProductName = "Smart Thermostat", RegularPrice = 149.99m, AvailableQuantity = 60, SKU = "ST021" },
            new Product { ProductID = 22, ActualProductName = "UV Sterilizer", RegularPrice = 59.99m, AvailableQuantity = 100, SKU = "UVS022" },
            new Product { ProductID = 23, ActualProductName = "Wireless Charging Pad", RegularPrice = 34.99m, AvailableQuantity = 150, SKU = "WCP023" },
            new Product { ProductID = 24, ActualProductName = "Waterproof Bluetooth", RegularPrice = 99.99m, AvailableQuantity = 70, SKU = "WBSP024" },
            new Product { ProductID = 25, ActualProductName = "Retro Gaming Console", RegularPrice = 179.99m, AvailableQuantity = 40, SKU = "RGC025" },
            new Product { ProductID = 26, ActualProductName = "Streaming Media Player", RegularPrice = 79.99m, AvailableQuantity = 90, SKU = "SMP026" },
            new Product { ProductID = 27, ActualProductName = "Digital Photo Frame", RegularPrice = 49.99m, AvailableQuantity = 120, SKU = "DPF027" },
            new Product { ProductID = 28, ActualProductName = "Electric Kettle", RegularPrice = 29.99m, AvailableQuantity = 200, SKU = "EK028" },
            new Product { ProductID = 29, ActualProductName = "Smart Door Lock", RegularPrice = 249.99m, AvailableQuantity = 50, SKU = "SDL029" },
            new Product { ProductID = 30, ActualProductName = "Bluetooth Game", RegularPrice = 69.99m, AvailableQuantity = 80, SKU = "BGC030" },
             new Product { ProductID = 31, ActualProductName = "Wireless Router", RegularPrice = 79.99m, AvailableQuantity = 100, SKU = "WR031" },
            new Product { ProductID = 32, ActualProductName = "Home Security Camera", RegularPrice = 149.99m, AvailableQuantity = 60, SKU = "HSC032" },
            new Product { ProductID = 33, ActualProductName = "Electric Shaver", RegularPrice = 49.99m, AvailableQuantity = 120, SKU = "ES033" },
            new Product { ProductID = 34, ActualProductName = "Smart Scale", RegularPrice = 39.99m, AvailableQuantity = 150, SKU = "SS034" },
            new Product { ProductID = 35, ActualProductName = "Portable Blender", RegularPrice = 29.99m, AvailableQuantity = 200, SKU = "PB035" },
            new Product { ProductID = 36, ActualProductName = "LED Desk Lamp", RegularPrice = 24.99m, AvailableQuantity = 250, SKU = "LDL036" },
            new Product { ProductID = 37, ActualProductName = "Cordless Drill", RegularPrice = 99.99m, AvailableQuantity = 70, SKU = "CD037" },
            new Product { ProductID = 38, ActualProductName = "HDMI Transmitter", RegularPrice = 149.99m, AvailableQuantity = 90, SKU = "WHT038" },
            new Product { ProductID = 39, ActualProductName = "Smart Plug", RegularPrice = 19.99m, AvailableQuantity = 120, SKU = "SP039" },
            new Product { ProductID = 40, ActualProductName = "Barcode Scanner", RegularPrice = 89.99m, AvailableQuantity = 80, SKU = "BBS040" }
             };

        }

		public async Task<List<Product>> GetAllProductsServerPaginated(InventoryProductFilterModel inventoryProductFilterModel)
		{
			try
			{
				var response = await _apiManager.PostAsync<List<Product>>(AppConstants.baseAddress + "/materialLabor/GetAllProductsServerPaginated" , inventoryProductFilterModel);
				return response;
			}
			catch (Exception ex)
			{
				return new List<Product>();
			}
		}
	}
}
