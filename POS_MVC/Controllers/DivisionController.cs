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
    public class DivisionController : Controller
    {
        private posEntities db = new posEntities();

        // GET: /Division/
        public ActionResult Index()
        {
            var loc_statedivision = db.loc_statedivision.Include(l => l.loc_country);
            return View(loc_statedivision.ToList());
        }

        // GET: /Division/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loc_statedivision loc_statedivision = db.loc_statedivision.Find(id);
            if (loc_statedivision == null)
            {
                return HttpNotFound();
            }
            return View(loc_statedivision);
        }

        // GET: /Division/Create
        public ActionResult Create()
        {
            ViewBag.country_id = new SelectList(db.loc_country, "country_id", "country_name");
            return View();
        }

        // POST: /Division/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="statedivision_id,country_id,statedivision_name")] loc_statedivision loc_statedivision)
        {
            if (ModelState.IsValid)
            {
                db.loc_statedivision.Add(loc_statedivision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.country_id = new SelectList(db.loc_country, "country_id", "country_name", loc_statedivision.country_id);
            return View(loc_statedivision);
        }

        // GET: /Division/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loc_statedivision loc_statedivision = db.loc_statedivision.Find(id);
            if (loc_statedivision == null)
            {
                return HttpNotFound();
            }
            ViewBag.country_id = new SelectList(db.loc_country, "country_id", "country_name", loc_statedivision.country_id);
            return View(loc_statedivision);
        }

        // POST: /Division/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="statedivision_id,country_id,statedivision_name")] loc_statedivision loc_statedivision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loc_statedivision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.country_id = new SelectList(db.loc_country, "country_id", "country_name", loc_statedivision.country_id);
            return View(loc_statedivision);
        }

        // GET: /Division/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loc_statedivision loc_statedivision = db.loc_statedivision.Find(id);
            if (loc_statedivision == null)
            {
                return HttpNotFound();
            }
            return View(loc_statedivision);
        }

        // POST: /Division/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loc_statedivision loc_statedivision = db.loc_statedivision.Find(id);
            db.loc_statedivision.Remove(loc_statedivision);
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
