using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Enums
{
	public enum QuoteActionEnum
	{
		ServiceTypeAdded,
		ServiceTypeRemoved,
		ServiceTypeUpdated,
		LineItemAdded,
		LineItemRemoved,
		LineItemUpdated,
		DiscountChanged
	}
}
