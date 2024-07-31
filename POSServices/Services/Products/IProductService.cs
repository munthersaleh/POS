﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSModel.Models;
namespace POSServices.Services.Products
{
	public interface IProductService
	{
		Task<List<Product>> GetAllInventoryProducts();

        Task<List<Product>> GetAllNonInventoryProducts();

		Task<List<Product>> GetAllProductsServerPaginated(InventoryProductFilterModel inventoryProductFilterModel);


	}
}
