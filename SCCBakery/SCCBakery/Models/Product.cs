using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCCBakery.Models
{
    [Table("Products")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }
        [Display(Name = "Product Desctiption")]
        public string ProductDescription { get; set; }

        [Required]
        [Display(Name = "Product Cost")]
        public decimal ProductPrice { get; set; }

        [Required]
        [Display(Name = "Product Image")]
        public string ImagePath { get; set; }

    }
}