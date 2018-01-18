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
    public class CoffeeShopController : Controller
    {
        private CoffeeSoftDbContext db = new CoffeeSoftDbContext();

        // GET: CoffeeShop
        public ActionResult Index()
        {
            return View(db.CoffeeShops.ToList());
        }

        // GET: CoffeeShop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeShop CoffeeShop = db.CoffeeShops.Find(id);
            if (CoffeeShop == null)
            {
                return HttpNotFound();
            }
            return View(CoffeeShop);
        }

        // GET: CoffeeShop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoffeeShop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CoffeeShopName,CoffeeShopAddress")] CoffeeShop CoffeeShop)
        {
            if (ModelState.IsValid)
            {
                db.CoffeeShops.Add(CoffeeShop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(CoffeeShop);
        }

        // GET: CoffeeShop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeShop CoffeeShop = db.CoffeeShops.Find(id);
            if (CoffeeShop == null)
            {
                return HttpNotFound();
            }
            return View(CoffeeShop);
        }

        // POST: CoffeeShop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CoffeeShopName,CoffeeShopAddress")] CoffeeShop CoffeeShop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(CoffeeShop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(CoffeeShop);
        }

        // GET: CoffeeShop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeShop CoffeeShop = db.CoffeeShops.Find(id);
            if (CoffeeShop == null)
            {
                return HttpNotFound();
            }
            return View(CoffeeShop);
        }

        // POST: CoffeeShop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoffeeShop CoffeeShop = db.CoffeeShops.Find(id);
            db.CoffeeShops.Remove(CoffeeShop);
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
