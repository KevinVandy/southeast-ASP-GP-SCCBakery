using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCCBakery.Models;
using System.Net;
using System.Collections;
using System.Data.Entity;

namespace SCCBakery.Controllers
{
    public class OrderInvoiceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: OrderInvoice
        public ActionResult Index()
        {
            return View(db.AnOrder.ToList());
        }

        public ActionResult ViewOrderInvoice(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Invoice order = new Invoice();
            Invoice o = new Invoice();

            //var order = db.AnInvoice.Find(o.OrderID = (int)id);
            //List<Invoice> order = new List<Invoice>();
            //order.Add(db.AnInvoice.Include(i => i.TheOrder).Include(i => i.TheProduct).Where(x => x.OrderID == id));
            var order = (db.AnInvoice.Include(i => i.TheOrder).Include(i => i.TheProduct).Where(x => x.OrderID == id)).ToList();
            //.FirstOrDefault(x => x.OrderID == id));


            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }
    }
}