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
    public class CountryController : Controller
    {
        private posEntities db = new posEntities();

        // GET: /Country/
        public ActionResult Index()
        {
            return View(db.loc_country.ToList());
        }

        // GET: /Country/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loc_country loc_country = db.loc_country.Find(id);
            if (loc_country == null)
            {
                return HttpNotFound();
            }
            return View(loc_country);
        }

        // GET: /Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Country/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="country_id,country_name")] loc_country loc_country)
        {
            if (ModelState.IsValid)
            {
                db.loc_country.Add(loc_country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loc_country);
        }

        // GET: /Country/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loc_country loc_country = db.loc_country.Find(id);
            if (loc_country == null)
            {
                return HttpNotFound();
            }
            return View(loc_country);
        }

        // POST: /Country/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="country_id,country_name")] loc_country loc_country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loc_country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loc_country);
        }

        // GET: /Country/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loc_country loc_country = db.loc_country.Find(id);
            if (loc_country == null)
            {
                return HttpNotFound();
            }
            return View(loc_country);
        }

        // POST: /Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loc_country loc_country = db.loc_country.Find(id);
            db.loc_country.Remove(loc_country);
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
