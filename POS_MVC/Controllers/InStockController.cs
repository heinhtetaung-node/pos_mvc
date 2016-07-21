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
    public class InStockController : Controller
    {
        private posEntities db = new posEntities();

        // GET: /InStock/
        public ActionResult Index()
        {
            var stock_in_products = db.stock_in_products.Include(s => s.avail_stock_products).Include(s => s.loc_stock_location).Include(s => s.stock_in).Include(s => s.supplier);
            return View(stock_in_products.ToList());
        }

        // GET: /InStock/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock_in_products stock_in_products = db.stock_in_products.Find(id);
            if (stock_in_products == null)
            {
                return HttpNotFound();
            }
            return View(stock_in_products);
        }

        // GET: /InStock/Create
        public ActionResult Create()
        {
            ViewBag.product_id = new SelectList(db.avail_stock_products, "product_id", "product_name");
            ViewBag.stock_location_id = new SelectList(db.loc_stock_location, "stock_location_id", "stock_location_name");
            ViewBag.stock_in_id = new SelectList(db.stock_in, "stock_in_id", "stock_in_id");
            ViewBag.supplier_id = new SelectList(db.suppliers, "supplier_id", "supplier_name");
            return View();
        }

        // POST: /InStock/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="stock_in_products_id,stock_in_id,product_id,product_buy_pric,product_sell_default_price,product_qty,stock_status,additional_cost,supplier_id,stock_location_id,stock_in_time")] stock_in_products stock_in_products)
        {
            if (ModelState.IsValid)
            {
                db.stock_in_products.Add(stock_in_products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.product_id = new SelectList(db.avail_stock_products, "product_id", "product_name", stock_in_products.product_id);
            ViewBag.stock_location_id = new SelectList(db.loc_stock_location, "stock_location_id", "stock_location_name", stock_in_products.stock_location_id);
            ViewBag.stock_in_id = new SelectList(db.stock_in, "stock_in_id", "stock_in_id", stock_in_products.stock_in_id);
            ViewBag.supplier_id = new SelectList(db.suppliers, "supplier_id", "supplier_name", stock_in_products.supplier_id);
            return View(stock_in_products);
        }

        // GET: /InStock/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock_in_products stock_in_products = db.stock_in_products.Find(id);
            if (stock_in_products == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_id = new SelectList(db.avail_stock_products, "product_id", "product_name", stock_in_products.product_id);
            ViewBag.stock_location_id = new SelectList(db.loc_stock_location, "stock_location_id", "stock_location_name", stock_in_products.stock_location_id);
            ViewBag.stock_in_id = new SelectList(db.stock_in, "stock_in_id", "stock_in_id", stock_in_products.stock_in_id);
            ViewBag.supplier_id = new SelectList(db.suppliers, "supplier_id", "supplier_name", stock_in_products.supplier_id);
            return View(stock_in_products);
        }

        // POST: /InStock/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="stock_in_products_id,stock_in_id,product_id,product_buy_pric,product_sell_default_price,product_qty,stock_status,additional_cost,supplier_id,stock_location_id,stock_in_time")] stock_in_products stock_in_products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock_in_products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_id = new SelectList(db.avail_stock_products, "product_id", "product_name", stock_in_products.product_id);
            ViewBag.stock_location_id = new SelectList(db.loc_stock_location, "stock_location_id", "stock_location_name", stock_in_products.stock_location_id);
            ViewBag.stock_in_id = new SelectList(db.stock_in, "stock_in_id", "stock_in_id", stock_in_products.stock_in_id);
            ViewBag.supplier_id = new SelectList(db.suppliers, "supplier_id", "supplier_name", stock_in_products.supplier_id);
            return View(stock_in_products);
        }

        // GET: /InStock/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock_in_products stock_in_products = db.stock_in_products.Find(id);
            if (stock_in_products == null)
            {
                return HttpNotFound();
            }
            return View(stock_in_products);
        }

        // POST: /InStock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stock_in_products stock_in_products = db.stock_in_products.Find(id);
            db.stock_in_products.Remove(stock_in_products);
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
