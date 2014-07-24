using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    [MetadataType(typeof(CategoryValidation))]
    public partial class Category { }

    public class CategoryValidation
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Display(Name="Parent Category")]
        public Nullable<int> ParentID { get; set; }
    
    }
}