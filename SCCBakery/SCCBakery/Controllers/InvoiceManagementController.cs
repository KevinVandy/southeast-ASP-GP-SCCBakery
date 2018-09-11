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
    public class InvoiceManagementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InvoiceManagement
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            var anInvoice = db.AnInvoice.Include(i => i.TheOrder).Include(i => i.TheProduct);

            return View(anInvoice.ToList());
        }

        // GET: InvoiceManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.AnInvoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: InvoiceManagement/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.AnOrder, "OrderID", "OrderID");
            ViewBag.ProductID = new SelectList(db.AProduct, "ProductID", "ProductName");
            return View();
        }

        // POST: InvoiceManagement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceID,OrderID,ProductID,Quantity")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.AnInvoice.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.AnOrder, "OrderID", "OrderID", invoice.OrderID);
            ViewBag.ProductID = new SelectList(db.AProduct, "ProductID", "ProductName", invoice.ProductID);
            return View(invoice);
        }

        // GET: InvoiceManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.AnInvoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.AnOrder, "OrderID", "OrderID", invoice.OrderID);
            ViewBag.ProductID = new SelectList(db.AProduct, "ProductID", "ProductName", invoice.ProductID);
            return View(invoice);
        }

        // POST: InvoiceManagement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceID,OrderID,ProductID,Quantity")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.AnOrder, "OrderID", "OrderID", invoice.OrderID);
            ViewBag.ProductID = new SelectList(db.AProduct, "ProductID", "ProductName", invoice.ProductID);
            return View(invoice);
        }

        // GET: InvoiceManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.AnInvoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: InvoiceManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.AnInvoice.Find(id);
            db.AnInvoice.Remove(invoice);
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
