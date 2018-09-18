using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCCBakery.Models;

namespace SCCBakery.Controllers
{


    public class CartsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        
        // GET: Carts
        public ActionResult Index(int? id, int? quantity)
        {
            if (Session["CartItems"] == null)
            {
                Session["CartItems"] = new List<Invoice>();
            }

            if(quantity == null)
            {
                quantity = 1;
            }
            
            if (id != null)
            {
                Invoice anInvoice = new Invoice();
                anInvoice.InvoiceID = 0;
                anInvoice.OrderID = 0;
                anInvoice.TheProduct = db.AProduct.FirstOrDefault(x => x.ProductID == id);
                anInvoice.Quantity = (short)quantity;
                
                bool shouldAdd = true;

                foreach(Invoice i in (List<Invoice>)Session["CartItems"])
                {
                    if (i.ProductID == id)
                    {
                        i.Quantity++;
                        shouldAdd = false;
                        break;
                    }
                }
                if(shouldAdd)
                {
                    ((List<Invoice>)Session["CartItems"]).Add(anInvoice);
                }
                
            }

            //id = null; //set to null to avoid bug
            
            return View(Session["CartItems"]);
        }

        [Authorize]
        public ActionResult CreateOrder()
        {
            Order theOrder = new Order();
            decimal orderTotal = 0;
            DateTime orderTime = new DateTime().ToLocalTime();


            foreach (Invoice i in ((List<Invoice>)Session["CartItems"]))
            {
                orderTotal += i.TheProduct.ProductPrice * i.Quantity;
            }

            theOrder = new Order(1, orderTime, orderTotal);

            db.AnOrder.Add(theOrder);

            foreach (Invoice i in ((List<Invoice>)Session["CartItems"]))
            {
                db.AnInvoice.Add(i);    
            }

            db.SaveChanges();

            return View(theOrder);
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CartID,CustomerID")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cart);
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartID,CustomerID")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
