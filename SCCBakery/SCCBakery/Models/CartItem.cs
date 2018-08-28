using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCCBakery.Models
{
    public class CartItem : IEquatable<CartItem>
    {
        public bool Equals(CartItem other)
        {
            throw new NotImplementedException();
        }

        List<CartItem> Items { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}