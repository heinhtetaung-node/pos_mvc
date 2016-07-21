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
    public class ProductsController : Controller
    {
        private posEntities db = new posEntities();

        // GET: /Products/
        public ActionResult Index()
        {
            var avail_stock_products = db.avail_stock_products.Include(a => a.category).Include(a => a.subcategory);
            return View(avail_stock_products.ToList());
        }

        // GET: /Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            avail_stock_products avail_stock_products = db.avail_stock_products.Find(id);
            if (avail_stock_products == null)
            {
                return HttpNotFound();
            }
            return View(avail_stock_products);
        }

        public JsonResult getProduct(int? id)
        {
            /*
            select with entity
            db.Configuration.ProxyCreationEnabled = false;
            avail_stock_products model = db.avail_stock_products.Find(id);
            */

            // select with ado.net
            var model = (from p in db.avail_stock_products
                         join c in db.categories on p.category_id equals c.category_id
                         join sc in db.subcategories on p.subcategory_id equals sc.category_id
                         where p.product_id == id
                         select new product_model
                         {
                             product_id = p.product_id,
                             product_name = p.product_name,
                             category_id = p.category_id,
                             subcategory_id = p.subcategory_id,
                             qty = p.qty,
                             current_price = p.current_price,
                             cost = p.cost,
                             category_name = c.category_name,
                             subcategory_name = sc.subcategory_name
                         }).ToList();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // GET: /Products/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name");
            ViewBag.subcategory_id = new SelectList(db.subcategories, "subcategory_id", "subcategory_name");
            return View();
        }

        // POST: /Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="product_id,product_name,category_id,subcategory_id,qty,current_price,cost")] avail_stock_products avail_stock_products)
        {
            if (ModelState.IsValid)
            {
                db.avail_stock_products.Add(avail_stock_products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", avail_stock_products.category_id);
            ViewBag.subcategory_id = new SelectList(db.subcategories, "subcategory_id", "subcategory_name", avail_stock_products.subcategory_id);
            return View(avail_stock_products);
        }

        // GET: /Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            avail_stock_products avail_stock_products = db.avail_stock_products.Find(id);
            if (avail_stock_products == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", avail_stock_products.category_id);
            ViewBag.subcategory_id = new SelectList(db.subcategories, "subcategory_id", "subcategory_name", avail_stock_products.subcategory_id);
            return View(avail_stock_products);
        }

        // POST: /Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="product_id,product_name,category_id,subcategory_id,qty,current_price,cost")] avail_stock_products avail_stock_products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(avail_stock_products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", avail_stock_products.category_id);
            ViewBag.subcategory_id = new SelectList(db.subcategories, "subcategory_id", "subcategory_name", avail_stock_products.subcategory_id);
            return View(avail_stock_products);
        }

        // GET: /Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            avail_stock_products avail_stock_products = db.avail_stock_products.Find(id);
            if (avail_stock_products == null)
            {
                return HttpNotFound();
            }
            return View(avail_stock_products);
        }

        // POST: /Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            avail_stock_products avail_stock_products = db.avail_stock_products.Find(id);
            db.avail_stock_products.Remove(avail_stock_products);
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
