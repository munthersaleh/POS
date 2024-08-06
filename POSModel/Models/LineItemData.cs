using POSModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
    public class LineItemData
    {
        public LineItemActionEnum LineItemAction {  get; set; }
        public object NewValue { get; set; }
        public int? LineItemID { get; set; }
    }
}
