using POSModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSServices.Services.Products
{
	public class ProductService : IProductService
	{
		public async Task<List<Product>> GetAllProducts()
		{
			
			var random = new Random();
			

			List<Product> productList = new List<Product>
	     	{
			new Product { ProductId = 1, Name = "Gaming Laptop", UnitPrice = 1299.99m, AvailableStock = 50, Sku = "GLP001" },
			new Product { ProductId = 2, Name = "Smartphone", UnitPrice = 699.99m, AvailableStock = 100, Sku = "SPH002" },
			new Product { ProductId = 3, Name = "Bluetooth Headphones", UnitPrice = 149.99m, AvailableStock = 150, Sku = "BHP003" },
			new Product { ProductId = 4, Name = "4K Smart TV", UnitPrice = 899.99m, AvailableStock = 30, Sku = "TV004" },
			new Product { ProductId = 5, Name = "Fitness Tracker", UnitPrice = 79.99m, AvailableStock = 200, Sku = "FT005" },
			new Product { ProductId = 6, Name = "External Hard Drive", UnitPrice = 129.99m, AvailableStock = 80, Sku = "EHD006" },
			new Product { ProductId = 7, Name = "Wireless Keyboard", UnitPrice = 59.99m, AvailableStock = 120, Sku = "WKM007" },
			new Product { ProductId = 8, Name = "Coffee Maker", UnitPrice = 49.99m, AvailableStock = 180, Sku = "CM008" },
			new Product { ProductId = 9, Name = "Bluetooth Speaker", UnitPrice = 89.99m, AvailableStock = 90, Sku = "BSP009" },
			new Product { ProductId = 10, Name = "Electric Toothbrush", UnitPrice = 39.99m, AvailableStock = 150, Sku = "ETB010" },
			new Product { ProductId = 11, Name = "Air Fryer", UnitPrice = 129.99m, AvailableStock = 60, Sku = "AF011" },
			new Product { ProductId = 12, Name = "Robot Vacuum", UnitPrice = 299.99m, AvailableStock = 40, Sku = "RVC012" },
			new Product { ProductId = 13, Name = "Portable Power Bank", UnitPrice = 29.99m, AvailableStock = 250, Sku = "PPB013" },
			new Product { ProductId = 14, Name = "Monitor Stand", UnitPrice = 49.99m, AvailableStock = 100, Sku = "MS014" },
			new Product { ProductId = 15, Name = "Wireless Earbuds", UnitPrice = 129.99m, AvailableStock = 70, Sku = "WEB015" },
			new Product { ProductId = 16, Name = "Backpack", UnitPrice = 79.99m, AvailableStock = 120, Sku = "BP016" },
			new Product { ProductId = 17, Name = "Smart Watch", UnitPrice = 199.99m, AvailableStock = 80, Sku = "SW017" },
			new Product { ProductId = 18, Name = "Desktop Computer", UnitPrice = 1499.99m, AvailableStock = 30, Sku = "DC018" },
			new Product { ProductId = 19, Name = "Portable Bluetooth", UnitPrice = 199.99m, AvailableStock = 50, Sku = "PBP019" },
			new Product { ProductId = 20, Name = "Electric Scooter", UnitPrice = 399.99m, AvailableStock = 25, Sku = "ES020" },
			new Product { ProductId = 21, Name = "Smart Thermostat", UnitPrice = 149.99m, AvailableStock = 60, Sku = "ST021" },
			new Product { ProductId = 22, Name = "UV Sterilizer", UnitPrice = 59.99m, AvailableStock = 100, Sku = "UVS022" },
			new Product { ProductId = 23, Name = "Wireless Charging Pad", UnitPrice = 34.99m, AvailableStock = 150, Sku = "WCP023" },
			new Product { ProductId = 24, Name = "Waterproof Bluetooth", UnitPrice = 99.99m, AvailableStock = 70, Sku = "WBSP024" },
			new Product { ProductId = 25, Name = "Retro Gaming Console", UnitPrice = 179.99m, AvailableStock = 40, Sku = "RGC025" },
			new Product { ProductId = 26, Name = "Streaming Media Player", UnitPrice = 79.99m, AvailableStock = 90, Sku = "SMP026" },
			new Product { ProductId = 27, Name = "Digital Photo Frame", UnitPrice = 49.99m, AvailableStock = 120, Sku = "DPF027" },
			new Product { ProductId = 28, Name = "Electric Kettle", UnitPrice = 29.99m, AvailableStock = 200, Sku = "EK028" },
			new Product { ProductId = 29, Name = "Smart Door Lock", UnitPrice = 249.99m, AvailableStock = 50, Sku = "SDL029" },
			new Product { ProductId = 30, Name = "Bluetooth Game", UnitPrice = 69.99m, AvailableStock = 80, Sku = "BGC030" },
			 new Product { ProductId = 31, Name = "Wireless Router", UnitPrice = 79.99m, AvailableStock = 100, Sku = "WR031" },
			new Product { ProductId = 32, Name = "Home Security Camera", UnitPrice = 149.99m, AvailableStock = 60, Sku = "HSC032" },
			new Product { ProductId = 33, Name = "Electric Shaver", UnitPrice = 49.99m, AvailableStock = 120, Sku = "ES033" },
			new Product { ProductId = 34, Name = "Smart Scale", UnitPrice = 39.99m, AvailableStock = 150, Sku = "SS034" },
			new Product { ProductId = 35, Name = "Portable Blender", UnitPrice = 29.99m, AvailableStock = 200, Sku = "PB035" },
			new Product { ProductId = 36, Name = "LED Desk Lamp", UnitPrice = 24.99m, AvailableStock = 250, Sku = "LDL036" },
			new Product { ProductId = 37, Name = "Cordless Drill", UnitPrice = 99.99m, AvailableStock = 70, Sku = "CD037" },
			new Product { ProductId = 38, Name = "HDMI Transmitter", UnitPrice = 149.99m, AvailableStock = 90, Sku = "WHT038" },
			new Product { ProductId = 39, Name = "Smart Plug", UnitPrice = 19.99m, AvailableStock = 120, Sku = "SP039" },
			new Product { ProductId = 40, Name = "Barcode Scanner", UnitPrice = 89.99m, AvailableStock = 80, Sku = "BBS040" }
			 };

			int i = 10001;
			foreach(var product in productList)
			{
				product.ItemCode = i.ToString();
				i += 1;
			}
			
			return productList;
			
		}
	}
}
