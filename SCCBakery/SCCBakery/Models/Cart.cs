using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCCBakery.Models
{
    [Table("Carts")]
    public class Cart
    {
        public int CartID { get; set; }

        public int CustomerID { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}