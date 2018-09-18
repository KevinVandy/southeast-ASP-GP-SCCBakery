using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCCBakery.Models
{
    [Table("Orders")]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        
        public int CustomerID { get; set; }

        
        public DateTime OrderTime { get; set; }

        
        public decimal OrderTotal { get; set; }

        public Order() { }

        public Order(int customerId, DateTime orderTime, decimal orderTotal)
        {
            CustomerID = customerId;
            OrderTime = orderTime;
            OrderTotal = orderTotal;
        }
    }
}