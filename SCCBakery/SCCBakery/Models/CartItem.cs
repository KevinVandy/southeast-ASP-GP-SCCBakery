using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCCBakery.Models
{
    [Table("CartItems")]
    public class CartItem
    {
        public string CartItemID { get; set; }

        public int CartID { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }


    }
}