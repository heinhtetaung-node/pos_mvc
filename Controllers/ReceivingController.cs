using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POS_MVC.Models;

namespace POS_MVC.Controllers
{
    public class ReceivingController : Controller
    {
        private posEntities db = new posEntities();

        // GET: /Receiving/
        public ActionResult Index()
        {
            var stock_in = db.stock_in.Include(s => s.admin_user).Include(s => s.total_daily_transition).Include(s => s.supplier).Include(s => s.supplier_payment_left);
            return View(stock_in.ToList());
        }

        // GET: /Receiving/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock_in stock_in = db.stock_in.Find(id);
            if (stock_in == null)
            {
                return HttpNotFound();
            }
            return View(stock_in);
        }

        // GET: /Receiving/Create
        public ActionResult Create()
        {
            ViewBag.admin_user_id = new SelectList(db.admin_user, "id", "name");
            ViewBag.daily_transition_id = new SelectList(db.total_daily_transition, "daily_transition_id", "daily_transition_id");
            ViewBag.supplier_id = new SelectList(db.suppliers, "supplier_id", "supplier_name");
            ViewBag.supplier_payment_left_id = new SelectList(db.supplier_payment_left, "supplier_payment_left_id", "supplier_payment_left_id");
            ViewBag.stock_location_id = new SelectList(db.loc_stock_location, "stock_location_id", "stock_location_name");
            return View();
        }

        // POST: /Receiving/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="stock_in_id,stock_in_time,supplier_id,supplier_payment,qty_of_producttypes,paid,supplier_payment_left_id,move_to_stock,left_amount,paid_amount,return_amt,daily_transition_id,admin_user_id")] stock_in stock_in)
        {
            stock_in.stock_in_time = DateTime.Now;
            //Response.Write(stock_in.stock_in_time);
            //return Json(stock_in);
            
            if (ModelState.IsValid)
            {
                db.stock_in.Add(stock_in);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.admin_user_id = new SelectList(db.admin_user, "id", "name", stock_in.admin_user_id);
            ViewBag.daily_transition_id = new SelectList(db.total_daily_transition, "daily_transition_id", "daily_transition_id", stock_in.daily_transition_id);
            ViewBag.supplier_id = new SelectList(db.suppliers, "supplier_id", "supplier_name", stock_in.supplier_id);
            ViewBag.supplier_payment_left_id = new SelectList(db.supplier_payment_left, "supplier_payment_left_id", "supplier_payment_left_id", stock_in.supplier_payment_left_id);
            return View(stock_in); 
        }

        // GET: /Receiving/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock_in stock_in = db.stock_in.Find(id);
            if (stock_in == null)
            {
                return HttpNotFound();
            }
            ViewBag.admin_user_id = new SelectList(db.admin_user, "id", "name", stock_in.admin_user_id);
            ViewBag.daily_transition_id = new SelectList(db.total_daily_transition, "daily_transition_id", "daily_transition_id", stock_in.daily_transition_id);
            ViewBag.supplier_id = new SelectList(db.suppliers, "supplier_id", "supplier_name", stock_in.supplier_id);
            ViewBag.supplier_payment_left_id = new SelectList(db.supplier_payment_left, "supplier_payment_left_id", "supplier_payment_left_id", stock_in.supplier_payment_left_id);
            return View(stock_in);
        }

        // POST: /Receiving/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="stock_in_id,stock_in_time,supplier_id,supplier_payment,qty_of_producttypes,paid,supplier_payment_left_id,move_to_stock,left_amount,paid_amount,return_amt,daily_transition_id,admin_user_id")] stock_in stock_in)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock_in).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.admin_user_id = new SelectList(db.admin_user, "id", "name", stock_in.admin_user_id);
            ViewBag.daily_transition_id = new SelectList(db.total_daily_transition, "daily_transition_id", "daily_transition_id", stock_in.daily_transition_id);
            ViewBag.supplier_id = new SelectList(db.suppliers, "supplier_id", "supplier_name", stock_in.supplier_id);
            ViewBag.supplier_payment_left_id = new SelectList(db.supplier_payment_left, "supplier_payment_left_id", "supplier_payment_left_id", stock_in.supplier_payment_left_id);
            return View(stock_in);
        }

        // GET: /Receiving/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock_in stock_in = db.stock_in.Find(id);
            if (stock_in == null)
            {
                return HttpNotFound();
            }
            return View(stock_in);
        }

        // POST: /Receiving/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stock_in stock_in = db.stock_in.Find(id);
            db.stock_in.Remove(stock_in);
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
