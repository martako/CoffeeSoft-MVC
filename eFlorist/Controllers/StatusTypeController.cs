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
    public class StatusTypeController : Controller
    {
        private CoffeeSoftDbContext db = new CoffeeSoftDbContext();

        // GET: StatusType
        public ActionResult Index()
        {
            return View(db.StatusTypes.ToList());
        }

        // GET: StatusType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusType statusType = db.StatusTypes.Find(id);
            if (statusType == null)
            {
                return HttpNotFound();
            }
            return View(statusType);
        }

        // GET: StatusType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StatusName")] StatusType statusType)
        {
            if (ModelState.IsValid)
            {
                db.StatusTypes.Add(statusType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusType);
        }

        // GET: StatusType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusType statusType = db.StatusTypes.Find(id);
            if (statusType == null)
            {
                return HttpNotFound();
            }
            return View(statusType);
        }

        // POST: StatusType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StatusName")] StatusType statusType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusType);
        }

        // GET: StatusType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusType statusType = db.StatusTypes.Find(id);
            if (statusType == null)
            {
                return HttpNotFound();
            }
            return View(statusType);
        }

        // POST: StatusType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusType statusType = db.StatusTypes.Find(id);
            db.StatusTypes.Remove(statusType);
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
