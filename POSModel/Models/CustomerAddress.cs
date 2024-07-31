using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
    public class CustomerAddress
    {
        public int AddressID { get; set; }
        public string FullAddress { get; set; }
        public bool IsDefault { get; set; }
        public int CustomerContactID { get; set; }
        public string AddressTitle { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
