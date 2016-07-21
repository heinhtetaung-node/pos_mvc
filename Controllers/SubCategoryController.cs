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
    public class SubCategoryController : Controller
    {
        private posEntities db = new posEntities();

        // GET: /SubCategory/
        public ActionResult Index()
        {
            var subcategories = db.subcategories.Include(s => s.category);
            return View(subcategories.ToList());
        }

        // GET: /SubCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategory subcategory = db.subcategories.Find(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }

        // GET: /SubCategory/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name");
            return View();
        }

        // POST: /SubCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="subcategory_id,subcategory_name,subcategory_description,category_id")] subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                db.subcategories.Add(subcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", subcategory.category_id);
            return View(subcategory);
        }

        // GET: /SubCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategory subcategory = db.subcategories.Find(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", subcategory.category_id);
            return View(subcategory);
        }

        // POST: /SubCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="subcategory_id,subcategory_name,subcategory_description,category_id")] subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.categories, "category_id", "category_name", subcategory.category_id);
            return View(subcategory);
        }

        // GET: /SubCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategory subcategory = db.subcategories.Find(id);
            if (subcategory == null)
            {
                return HttpNotFound();
            }
            return View(subcategory);
        }

        // POST: /SubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subcategory subcategory = db.subcategories.Find(id);
            db.subcategories.Remove(subcategory);
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
