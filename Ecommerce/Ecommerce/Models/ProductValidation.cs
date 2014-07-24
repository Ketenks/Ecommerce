using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    [MetadataType(typeof(ProductValidation))]
    public partial class Product { }

    public class ProductValidation
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public decimal ListPrice { get; set; }
        [Required]
        public bool InStock { get; set; }
        [Required]
        public int SupplierID { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}