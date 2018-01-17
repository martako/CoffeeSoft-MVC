using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoffeeSoft.Models;

namespace CoffeeSoft.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        private CoffeeSoftDbContext db = new CoffeeSoftDbContext();

        // GET: Invoice
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.CoffeeShop).Include(i => i.Order).Include(i => i.Warehouse);
            return View(invoices.ToList());
        }

        // GET: Invoice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoice/Create
        public ActionResult Create()
        {
            ViewBag.CoffeeShopId = new SelectList(db.CoffeeShops, "Id", "CoffeeShopName");
            ViewBag.Id = new SelectList(db.Orders, "Id", "OrderNo");
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "WarehouseName");
            return View();
        }

        // POST: Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InvoiceNo,WarehouseId,CoffeeShopId")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoffeeShopId = new SelectList(db.CoffeeShops, "Id", "CoffeeShopName", invoice.CoffeeShopId);
            ViewBag.Id = new SelectList(db.Orders, "Id", "OrderNo", invoice.Id);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "WarehouseName", invoice.WarehouseId);
            return View(invoice);
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoffeeShopId = new SelectList(db.CoffeeShops, "Id", "CoffeeShopName", invoice.CoffeeShopId);
            ViewBag.Id = new SelectList(db.Orders, "Id", "OrderNo", invoice.Id);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "WarehouseName", invoice.WarehouseId);
            return View(invoice);
        }

        // POST: Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InvoiceNo,WarehouseId,CoffeeShopId")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoffeeShopId = new SelectList(db.CoffeeShops, "Id", "CoffeeShopName", invoice.CoffeeShopId);
            ViewBag.Id = new SelectList(db.Orders, "Id", "OrderNo", invoice.Id);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "WarehouseName", invoice.WarehouseId);
            return View(invoice);
        }

        // GET: Invoice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
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
