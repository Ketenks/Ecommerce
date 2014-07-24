using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    [MetadataType(typeof(ReviewValidation))]
    public partial class Review { }

    public class ReviewValidation
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public System.DateTime DateCreated { get; set; }
        [Required, MaxLength(100)]
        public string UserName { get; set; }
        [Required, MaxLength(250)]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}