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
    public class FloristController : Controller
    {
        private CoffeeSoftDbContext db = new CoffeeSoftDbContext();

        // GET: Florist
        public ActionResult Index()
        {
            return View(db.Florists.ToList());
        }

        // GET: Florist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Florist florist = db.Florists.Find(id);
            if (florist == null)
            {
                return HttpNotFound();
            }
            return View(florist);
        }

        // GET: Florist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Florist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FloristName,FloristAddress")] Florist florist)
        {
            if (ModelState.IsValid)
            {
                db.Florists.Add(florist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(florist);
        }

        // GET: Florist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Florist florist = db.Florists.Find(id);
            if (florist == null)
            {
                return HttpNotFound();
            }
            return View(florist);
        }

        // POST: Florist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FloristName,FloristAddress")] Florist florist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(florist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(florist);
        }

        // GET: Florist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Florist florist = db.Florists.Find(id);
            if (florist == null)
            {
                return HttpNotFound();
            }
            return View(florist);
        }

        // POST: Florist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Florist florist = db.Florists.Find(id);
            db.Florists.Remove(florist);
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
