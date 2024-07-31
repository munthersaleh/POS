using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floorzap.POS.Components.Shared
{
    public partial class ProductOrderTotals
    {

        [Parameter]
        public decimal SubTotalPrice { get; set; }


        [Parameter]
        public decimal TaxPrice { get; set; }
        public decimal TotalPrice { get; private set; }

        protected override void OnParametersSet()
        {
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            TotalPrice = Math.Round(SubTotalPrice + TaxPrice, 2);
        }
    }
}
