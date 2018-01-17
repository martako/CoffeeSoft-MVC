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
    public class OrderItemController : Controller
    {
        private CoffeeSoftDbContext db = new CoffeeSoftDbContext();

        // GET: OrderItem
        public ActionResult Index()
        {
            var orderItems = db.OrderItems.Include(o => o.Item).Include(o => o.Order);
            return View(orderItems.ToList());
        }

        // GET: OrderItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // GET: OrderItem/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName");
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "OrderNo");
            return View();
        }


        // GET: OrderItem/Create
        public ActionResult CreateByOrderId(int orderId)
        {
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName");

            var selectList = new SelectList(db.Orders, "Id", "OrderNo");
            selectList.Single(x => x.Value == orderId.ToString()).Selected = true;
            ViewBag.OrderId = selectList;
            ViewBag.SelectedOrderId = orderId;
            return View();
        }

        // POST: OrderItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateByOrderId([Bind(Include = "Id,ItemQuantity,ItemId,OrderId")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                db.OrderItems.Add(orderItem);
                db.SaveChanges();
                return RedirectToAction("Edit", "Order", new { id = orderItem.OrderId });
            }

            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", orderItem.ItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "OrderNo", orderItem.OrderId);
            return View(orderItem);
        }

        // POST: OrderItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ItemQuantity,ItemId,OrderId")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                db.OrderItems.Add(orderItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", orderItem.ItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "OrderNo", orderItem.OrderId);
            return View(orderItem);
        }

        // GET: OrderItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", orderItem.ItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "OrderNo", orderItem.OrderId);
            return View(orderItem);
        }

        // POST: OrderItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemQuantity,ItemId,OrderId")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "ItemName", orderItem.ItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "Id", "OrderNo", orderItem.OrderId);
            return View(orderItem);
        }

        // GET: OrderItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // POST: OrderItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderItem orderItem = db.OrderItems.Find(id);
            db.OrderItems.Remove(orderItem);
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
