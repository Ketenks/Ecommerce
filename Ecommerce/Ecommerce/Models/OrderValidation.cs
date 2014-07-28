using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    [MetadataType(typeof(OrderValidation))]
    public partial class Order { }

    public class OrderValidation
    {
        [Required]
        public int Total { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        
        public string UserName { get; set; }
        public Nullable<int> BillingAddressID { get; set; }
        public Nullable<int> MailingAddressID { get; set; }
        public Nullable<int> PaymentID { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
        public decimal ShippingTotal { get; set; }
        [Required]
        public System.DateTime DateCreated { get; set; }

        public Nullable<System.DateTime> DateCompleted { get; set; }
        public Nullable<System.DateTime> DateShipped { get; set; }
        [Required]
        public string Status { get; set; }
    }
}