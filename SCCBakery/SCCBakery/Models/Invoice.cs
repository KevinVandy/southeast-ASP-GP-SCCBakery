using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCCBakery.Models
{
    [Table("Invoices")]
    public class Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceID { get; set; }

        public Order TheOrder { get; set; }
        [Required]
        public int OrderID {get; set;}

        public Products TheProduct { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public Int16 Quantity { get; set; }
    }
}