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
    public class TruckController : Controller
    {
        private CoffeeSoftDbContext db = new CoffeeSoftDbContext();

        // GET: Truck
        public ActionResult Index()
        {
            var trucks = db.Trucks.Include(t => t.TruckType);
            return View(trucks.ToList());
        }

        // GET: Truck/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truck truck = db.Trucks.Find(id);
            if (truck == null)
            {
                return HttpNotFound();
            }
            return View(truck);
        }

        // GET: Truck/Create
        public ActionResult Create()
        {
            ViewBag.TruckTypeId = new SelectList(db.TruckTypes, "Id", "TruckTypeName");
            return View();
        }

        // POST: Truck/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TruckName,Brand,RegistrationNo,TruckTypeId")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                db.Trucks.Add(truck);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TruckTypeId = new SelectList(db.TruckTypes, "Id", "TruckTypeName", truck.TruckTypeId);
            return View(truck);
        }

        // GET: Truck/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truck truck = db.Trucks.Find(id);
            if (truck == null)
            {
                return HttpNotFound();
            }
            ViewBag.TruckTypeId = new SelectList(db.TruckTypes, "Id", "TruckTypeName", truck.TruckTypeId);
            return View(truck);
        }

        // POST: Truck/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TruckName,Brand,RegistrationNo,TruckTypeId")] Truck truck)
        {
            if (ModelState.IsValid)
            {
                db.Entry(truck).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TruckTypeId = new SelectList(db.TruckTypes, "Id", "TruckTypeName", truck.TruckTypeId);
            return View(truck);
        }

        // GET: Truck/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truck truck = db.Trucks.Find(id);
            if (truck == null)
            {
                return HttpNotFound();
            }
            return View(truck);
        }

        // POST: Truck/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Truck truck = db.Trucks.Find(id);
            db.Trucks.Remove(truck);
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
