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
    public class LocationController : Controller
    {
        private posEntities db = new posEntities();

        // GET: /Location/
        public ActionResult Index()
        {
            var loc_stock_location = db.loc_stock_location.Include(l => l.loc_country).Include(l => l.loc_statedivision).Include(l => l.loc_township);
            return View(loc_stock_location.ToList());
        }

        // GET: /Location/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loc_stock_location loc_stock_location = db.loc_stock_location.Find(id);
            if (loc_stock_location == null)
            {
                return HttpNotFound();
            }
            return View(loc_stock_location);
        }

        // GET: /Location/Create
        public ActionResult Create()
        {
            ViewBag.country_id = new SelectList(db.loc_country, "country_id", "country_name");
            ViewBag.statedivision_id = new SelectList(db.loc_statedivision, "statedivision_id", "statedivision_name");
            ViewBag.township_id = new SelectList(db.loc_township, "township_id", "township_name");
            return View();
        }

        // POST: /Location/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="stock_location_id,stock_location_name,township_id,address,statedivision_id,country_id")] loc_stock_location loc_stock_location)
        {
            if (ModelState.IsValid)
            {
                db.loc_stock_location.Add(loc_stock_location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.country_id = new SelectList(db.loc_country, "country_id", "country_name", loc_stock_location.country_id);
            ViewBag.statedivision_id = new SelectList(db.loc_statedivision, "statedivision_id", "statedivision_name", loc_stock_location.statedivision_id);
            ViewBag.township_id = new SelectList(db.loc_township, "township_id", "township_name", loc_stock_location.township_id);
            return View(loc_stock_location);
        }

        // GET: /Location/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loc_stock_location loc_stock_location = db.loc_stock_location.Find(id);
            if (loc_stock_location == null)
            {
                return HttpNotFound();
            }
            ViewBag.country_id = new SelectList(db.loc_country, "country_id", "country_name", loc_stock_location.country_id);
            ViewBag.statedivision_id = new SelectList(db.loc_statedivision, "statedivision_id", "statedivision_name", loc_stock_location.statedivision_id);
            ViewBag.township_id = new SelectList(db.loc_township, "township_id", "township_name", loc_stock_location.township_id);
            return View(loc_stock_location);
        }

        // POST: /Location/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="stock_location_id,stock_location_name,township_id,address,statedivision_id,country_id")] loc_stock_location loc_stock_location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loc_stock_location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.country_id = new SelectList(db.loc_country, "country_id", "country_name", loc_stock_location.country_id);
            ViewBag.statedivision_id = new SelectList(db.loc_statedivision, "statedivision_id", "statedivision_name", loc_stock_location.statedivision_id);
            ViewBag.township_id = new SelectList(db.loc_township, "township_id", "township_name", loc_stock_location.township_id);
            return View(loc_stock_location);
        }

        // GET: /Location/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loc_stock_location loc_stock_location = db.loc_stock_location.Find(id);
            if (loc_stock_location == null)
            {
                return HttpNotFound();
            }
            return View(loc_stock_location);
        }

        // POST: /Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loc_stock_location loc_stock_location = db.loc_stock_location.Find(id);
            db.loc_stock_location.Remove(loc_stock_location);
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
