using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCCBakery.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }

        public static readonly Cart Instance;

        static Cart()
        {
            if (HttpContext.Current.Session["ASPNETCart"] == null)
            {
                Instance = new Cart();
                Instance.CartItems = new List<CartItem>();
                HttpContext.Current.Session["ASPNETCart"] = Instance;
            }
            else
            {
                Instance = (Cart)HttpContext.Current.Session["ASPNETCart"];
            }
        }

        protected Cart() { }

        //Cart functions
        public void AddItem(int productID)
        {
            CartItem newItem = new CartItem(productID);

            if (CartItems.Contains(newItem))
            {
                foreach (CartItem cartItem in CartItems)
                {
                    if (cartItem.Equals(newItem))
                    {
                        cartItem.Quantity++;
                    }
                }
            }
            else newItem.Quantity = 1;
            CartItems.Add(newItem);
        }

        public void SetItemQuantity(int productID, int quantity)
        {
            if(quantity == 0)
            {
                RemoveItem(productID);
            }
        }

        public void RemoveItem(int productID)
        {
            CartItem removedItem = new Models.CartItem(productID);
            CartItems.Remove(removedItem);
        }

        public decimal CalculateSubTotal()
        {
            decimal subTotal = 0;
            foreach (CartItem cartItem in CartItems)
            {
                subTotal += cartItem.CartItemTotalPrice;
            }
            return subTotal;
        }

    }
    
        


    
}