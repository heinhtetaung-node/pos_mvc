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
    public class TownshipController : Controller
    {
        private posEntities db = new posEntities();

        // GET: /Township/
        public ActionResult Index()
        {
            var loc_township = db.loc_township.Include(l => l.loc_country).Include(l => l.loc_statedivision);
            return View(loc_township.ToList());
        }

        // GET: /Township/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loc_township loc_township = db.loc_township.Find(id);
            if (loc_township == null)
            {
                return HttpNotFound();
            }
            return View(loc_township);
        }

        // GET: /Township/Create
        public ActionResult Create()
        {
            ViewBag.country_id = new SelectList(db.loc_country, "country_id", "country_name");
            ViewBag.statedivision_id = new SelectList(db.loc_statedivision, "statedivision_id", "statedivision_name");
            return View();
        }

        // POST: /Township/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="township_id,statedivision_id,country_id,township_name")] loc_township loc_township)
        {
            if (ModelState.IsValid)
            {
                db.loc_township.Add(loc_township);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.country_id = new SelectList(db.loc_country, "country_id", "country_name", loc_township.country_id);
            ViewBag.statedivision_id = new SelectList(db.loc_statedivision, "statedivision_id", "statedivision_name", loc_township.statedivision_id);
            return View(loc_township);
        }

        // GET: /Township/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loc_township loc_township = db.loc_township.Find(id);
            if (loc_township == null)
            {
                return HttpNotFound();
            }
            ViewBag.country_id = new SelectList(db.loc_country, "country_id", "country_name", loc_township.country_id);
            ViewBag.statedivision_id = new SelectList(db.loc_statedivision, "statedivision_id", "statedivision_name", loc_township.statedivision_id);
            return View(loc_township);
        }

        // POST: /Township/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="township_id,statedivision_id,country_id,township_name")] loc_township loc_township)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loc_township).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.country_id = new SelectList(db.loc_country, "country_id", "country_name", loc_township.country_id);
            ViewBag.statedivision_id = new SelectList(db.loc_statedivision, "statedivision_id", "statedivision_name", loc_township.statedivision_id);
            return View(loc_township);
        }

        // GET: /Township/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loc_township loc_township = db.loc_township.Find(id);
            if (loc_township == null)
            {
                return HttpNotFound();
            }
            return View(loc_township);
        }

        // POST: /Township/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loc_township loc_township = db.loc_township.Find(id);
            db.loc_township.Remove(loc_township);
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
