﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCCBakery.Models
{
    public class OrderInvoiceView
    {
        public Order anOrder { get; set; }
        public Invoice anInvoice { get; set; }
    }
}