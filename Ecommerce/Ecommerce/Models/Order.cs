//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ecommerce.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public Order()
        {
            this.OrderLines = new HashSet<OrderLine>();
        }
    
        public int OrderID { get; set; }
        public int Total { get; set; }
        public decimal UnitPrice { get; set; }
        public string UserName { get; set; }
        public Nullable<int> BillingAddressID { get; set; }
        public Nullable<int> MailingAddressID { get; set; }
        public Nullable<int> PaymentID { get; set; }
        public decimal Tax { get; set; }
        public decimal ShippingTotal { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateCompleted { get; set; }
        public Nullable<System.DateTime> DateShipped { get; set; }
        public string Status { get; set; }
    
        public virtual Address BillingAddress { get; set; }
        public virtual Address MailingAddress { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual Payment Payment { get; set; }
    }
}