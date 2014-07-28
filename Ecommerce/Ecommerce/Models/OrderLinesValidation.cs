using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    [MetadataType(typeof(OrderLinesValidation))]
    public partial class OrderLine { }

    public class OrderLinesValidation
    {
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
    }
}