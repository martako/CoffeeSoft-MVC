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
    public class WarehouseTypeController : Controller
    {
        private CoffeeSoftDbContext db = new CoffeeSoftDbContext();

        // GET: WarehouseType
        public ActionResult Index()
        {
            return View(db.WarehouseTypes.ToList());
        }

        // GET: WarehouseType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseType warehouseType = db.WarehouseTypes.Find(id);
            if (warehouseType == null)
            {
                return HttpNotFound();
            }
            return View(warehouseType);
        }

        // GET: WarehouseType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WarehouseType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WarehouseTypeName")] WarehouseType warehouseType)
        {
            if (ModelState.IsValid)
            {
                db.WarehouseTypes.Add(warehouseType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warehouseType);
        }

        // GET: WarehouseType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseType warehouseType = db.WarehouseTypes.Find(id);
            if (warehouseType == null)
            {
                return HttpNotFound();
            }
            return View(warehouseType);
        }

        // POST: WarehouseType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WarehouseTypeName")] WarehouseType warehouseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehouseType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warehouseType);
        }

        // GET: WarehouseType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WarehouseType warehouseType = db.WarehouseTypes.Find(id);
            if (warehouseType == null)
            {
                return HttpNotFound();
            }
            return View(warehouseType);
        }

        // POST: WarehouseType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WarehouseType warehouseType = db.WarehouseTypes.Find(id);
            db.WarehouseTypes.Remove(warehouseType);
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
