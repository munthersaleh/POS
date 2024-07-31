using POSModel.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floorzap.POS.Components.Shared
{   
    public partial class CartItem
    {
        [Parameter]
        public CartProduct cartProduct { get; set; }
        [Parameter]
        public EventCallback OnChangeCartItem { get; set; }
        [Parameter]
        public EventCallback<int> OnRemoveCartProduct { get; set; }
        public void HandleQuantityInput(ChangeEventArgs args)
        {
            if (int.TryParse(args.Value.ToString(), out int quantity))
            {
                cartProduct.Quantity = quantity;
                OnChangeCartItem.InvokeAsync();
            }

        }
        public void HandleUnitPriceInput(ChangeEventArgs args)
        {
            if (int.TryParse(args.Value.ToString(), out int unitPrice))
            {
                cartProduct.UnitPrice = unitPrice;
                OnChangeCartItem.InvokeAsync();
            }
        }
        public void HandleDiscountInput(ChangeEventArgs args)
        {
            if (int.TryParse(args.Value.ToString(), out int discount))
            {
                cartProduct.Discount = discount;
                OnChangeCartItem.InvokeAsync();
            }
        }
        private void HandleSalesTaxInput(ChangeEventArgs e)
        {
            cartProduct.IsSaleTax = (bool)e.Value;
            OnChangeCartItem.InvokeAsync();
        }
        private void RemoveProduct()
        {
            OnRemoveCartProduct.InvokeAsync(cartProduct.ProductId);
        }
    }
}
