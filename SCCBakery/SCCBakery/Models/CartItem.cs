using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCCBakery.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }

        //public int CartID { get; set; }

        //public System.DateTime OrderTime { get; set; }

        public virtual Products Product { get; set; }

        public int ProductID { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal CartItemPrice { get; set; }

        public decimal CartItemTotalPrice { get; set; }

        public CartItem() { }

        public CartItem(int productID)
        {
            this.ProductID = productID;
            this.Quantity = 1;
        }

        public CartItem(int productID, int quantity)
        {
            this.ProductID = productID;
            this.Quantity = quantity;
        }

        //used by Contains()
        public bool Equals(CartItem item)
        {
            return item.ProductID == ProductID;
        }
    }
}