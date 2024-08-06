using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace POSModel.Models
{
    public class LocationDetails
    {
        /// <summary>
		/// Gets or sets the LocationID value.
		/// </summary>
		public int LocationID { get; set; }

        /// <summary>
        /// Gets or sets the Title value.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the PhoneNumber value.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the FaxNumber value.
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// Gets or sets the EmailAddress value.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the AddressID value.
        /// </summary>
        public int AddressID { get; set; }

        /// <summary>
        /// Gets or sets the InvoicePrefix value.
        /// </summary>
        public string InvoicePrefix { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate value.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy value.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the SalesTax value.
        /// </summary>
        public decimal SalesTax { get; set; }

        /// <summary>
        /// Gets or sets the TimeZone value.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets the Culture value.
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        /// Gets or sets the InvoiceStartNumber value.
        /// </summary>
        public int InvoiceStartNumber { get; set; }


       
        public string FullAddress { get; set; }
        public string CreatedByFullName { get; set; }
        public string StreetNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Zip2 { get; set; }
        public bool? IsDefault { get; set; }

        public string Country { get; set; }
        public string QBReferenceID { get; set; }
        public int ClassID { get; set; }
        public decimal PstTax { get; set; }
        public bool? IsBritishColumbiaPST { get; set; }
        public bool? IsAddToExistingEmps { get; set; }
    }
}
