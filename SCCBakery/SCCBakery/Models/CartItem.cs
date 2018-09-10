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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CartItemID { get; set; }
        public Cart TheCart { get; set; }
        public int CartID { get; set; }

        public Product Product { get; set; }
        public int ProductID { get; set; }

        public int Quantity { get; set; }


    }
}