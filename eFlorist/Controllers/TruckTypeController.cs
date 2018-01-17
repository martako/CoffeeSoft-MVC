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
    public class TruckTypeController : Controller
    {
        private CoffeeSoftDbContext db = new CoffeeSoftDbContext();

        // GET: TruckType
        public ActionResult Index()
        {
            return View(db.TruckTypes.ToList());
        }

        // GET: TruckType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TruckType truckType = db.TruckTypes.Find(id);
            if (truckType == null)
            {
                return HttpNotFound();
            }
            return View(truckType);
        }

        // GET: TruckType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TruckType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TruckTypeName")] TruckType truckType)
        {
            if (ModelState.IsValid)
            {
                db.TruckTypes.Add(truckType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(truckType);
        }

        // GET: TruckType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TruckType truckType = db.TruckTypes.Find(id);
            if (truckType == null)
            {
                return HttpNotFound();
            }
            return View(truckType);
        }

        // POST: TruckType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TruckTypeName")] TruckType truckType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(truckType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(truckType);
        }

        // GET: TruckType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TruckType truckType = db.TruckTypes.Find(id);
            if (truckType == null)
            {
                return HttpNotFound();
            }
            return View(truckType);
        }

        // POST: TruckType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TruckType truckType = db.TruckTypes.Find(id);
            db.TruckTypes.Remove(truckType);
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
