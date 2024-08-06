using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using POSModel.Enums;
using POSModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floorzap.POS.Components.Shared
{
    public partial class ProductLineItem
    {
        [Parameter]
        public Material invoiceProduct { get; set; }
        
        [Parameter]
        public EventCallback<LineItemData> OnChangeLineItemData { get; set; }
        [Parameter]
        public EventCallback<int?> OnRemoveCartProduct { get; set; }

        public void HandleQuantityInput(ChangeEventArgs args)
        {
            if (int.TryParse(args.Value.ToString(), out int quantity))
            {
                LineItemData lineItemData = new LineItemData
                {
                    LineItemAction = LineItemActionEnum.TotalSQ,
                    NewValue = quantity,
                    LineItemID = invoiceProduct.UniqueMaterialID
                };
                OnChangeLineItemData.InvokeAsync(lineItemData) ;
            }
        }
        public void HandleUnitPriceInput(ChangeEventArgs args)
        {
            if (int.TryParse(args.Value.ToString(), out int unitPrice))
            {
                LineItemData lineItemData = new LineItemData
                {
                    LineItemAction = LineItemActionEnum.UnitPrice,
                    NewValue = unitPrice,
                    LineItemID = invoiceProduct.UniqueMaterialID
                };
                OnChangeLineItemData.InvokeAsync(lineItemData);
       
            }
        }
        public void HandleMarginInput(ChangeEventArgs args)
        {
            if (int.TryParse(args.Value.ToString(), out int margin))
            {
                LineItemData lineItemData = new LineItemData
                {
                    LineItemAction = LineItemActionEnum.Margin,
                    NewValue = margin,
                    LineItemID = invoiceProduct.UniqueMaterialID
                };
                OnChangeLineItemData.InvokeAsync(lineItemData);
            }
        }
        private void ChangeProductDiscountType()
        {
            invoiceProduct.ProductDiscountType = invoiceProduct.ProductDiscountType == (int)DiscountTypeEnum.Dollar ? (int)DiscountTypeEnum.Percent : (int)DiscountTypeEnum.Dollar;
        }
        public void HandleDiscountInput(ChangeEventArgs args)
        {
            if (int.TryParse(args.Value.ToString(), out int discount))
            {
                LineItemData lineItemData = new LineItemData
                {
                    LineItemAction = LineItemActionEnum.Discount,
                    NewValue = discount,
                    LineItemID = invoiceProduct.UniqueMaterialID
                };
                OnChangeLineItemData.InvokeAsync(lineItemData);
            }
        }
        private void HandleSalesTaxInput(ChangeEventArgs e)
        {
            LineItemData lineItemData = new LineItemData
            {
                LineItemAction = LineItemActionEnum.SalesTax,
                NewValue = (bool)e.Value,
                LineItemID = invoiceProduct.UniqueMaterialID
            };
            OnChangeLineItemData.InvokeAsync(lineItemData);
        }
        private void RemoveProduct()
        {
            OnRemoveCartProduct.InvokeAsync(invoiceProduct.UniqueMaterialID);
        }

        private bool ShouldDisableInput()
        {
            // Example condition
            return invoiceProduct.ProductDiscountAmount > 0 || invoiceProduct.ProductDiscount > 0;
        }

    }
}
