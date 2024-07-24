using Microsoft.AspNetCore.Components;
using POSModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floorzap.POS.Components.Shared
{
	public partial class OrderProduct
	{
		[Parameter]
		public CartProduct cartProduct { get; set; }

		[Parameter]
		public EventCallback OnChangeQuantity { get; set; }

		[Parameter]
		public EventCallback<int> OnRemoveCartProduct { get; set; }

		private bool showConfirmation = false;
		public void ReduceQuantity() {
		    if ( cartProduct.Quantity > 1) {
				cartProduct.Quantity--;
				OnChangeQuantity.InvokeAsync();
			}
		}
		public void IncreaseQuantity() {
			cartProduct.Quantity++;
			OnChangeQuantity.InvokeAsync();
		}

		public void HandleQuantityInput(ChangeEventArgs args)
		{
			if (int.TryParse(args.Value.ToString(), out int quantity))
			{
				cartProduct.Quantity = quantity;
				OnChangeQuantity.InvokeAsync();
			}

		}
		private void ShowConfirmation()
		{
			showConfirmation = true;
		}
		private void RemoveProduct(bool isRemove)
		{
			if(isRemove)
			{
				OnRemoveCartProduct.InvokeAsync(cartProduct.ProductId);
				showConfirmation = false;
			}
			else
			{
				showConfirmation = false;
			}
		}

		private string confirmationStyle => showConfirmation ? "display: flex;" : "display: none;";


	}
}
