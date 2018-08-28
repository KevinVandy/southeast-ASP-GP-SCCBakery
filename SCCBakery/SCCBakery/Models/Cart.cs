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
        public List<CartItem> Items { get; set; }

        static Cart()
        {
            //get and set sessions
            //if (HttpContext.Current.Session["ASPNETShoppingCart"] == null)
            //{
            //    Instance = new Cart();
            //    Instance.Items = new List<CartItem>();
            //    HttpContext.Current.Session["ASPNETShoppingCart"] = Instance;
            //}
            //else
            //{
            //    Instance = (Cart)HttpContext.Current.Session["ASPNETShoppingCart"];
            //}
        }

        protected Cart() { }

        public void AddItem(int productID)
        {

        }
    }
}