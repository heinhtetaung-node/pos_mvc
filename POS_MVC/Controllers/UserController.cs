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
    public class UserController : Controller
    {
        private posEntities db = new posEntities();

        // GET: /User/
        public ActionResult Index()
        {
            var admin_user = db.admin_user.Include(a => a.admin_role).Include(a => a.loc_stock_location);
            return View(admin_user.ToList());
        }

        // GET: /User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin_user admin_user = db.admin_user.Find(id);
            if (admin_user == null)
            {
                return HttpNotFound();
            }
            return View(admin_user);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            ViewBag.admin_role_id = new SelectList(db.admin_role, "admin_role_id", "role_name");
            ViewBag.stock_location_id = new SelectList(db.loc_stock_location, "stock_location_id", "stock_location_name");
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,email,username,password,admin_role_id,stock_location_id")] admin_user admin_user)
        {
            if (ModelState.IsValid)
            {
                db.admin_user.Add(admin_user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.admin_role_id = new SelectList(db.admin_role, "admin_role_id", "role_name", admin_user.admin_role_id);
            ViewBag.stock_location_id = new SelectList(db.loc_stock_location, "stock_location_id", "stock_location_name", admin_user.stock_location_id);
            return View(admin_user);
        }

        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin_user admin_user = db.admin_user.Find(id);
            if (admin_user == null)
            {
                return HttpNotFound();
            }
            ViewBag.admin_role_id = new SelectList(db.admin_role, "admin_role_id", "role_name", admin_user.admin_role_id);
            ViewBag.stock_location_id = new SelectList(db.loc_stock_location, "stock_location_id", "stock_location_name", admin_user.stock_location_id);
            return View(admin_user);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,email,username,password,admin_role_id,stock_location_id")] admin_user admin_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.admin_role_id = new SelectList(db.admin_role, "admin_role_id", "role_name", admin_user.admin_role_id);
            ViewBag.stock_location_id = new SelectList(db.loc_stock_location, "stock_location_id", "stock_location_name", admin_user.stock_location_id);
            return View(admin_user);
        }

        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin_user admin_user = db.admin_user.Find(id);
            if (admin_user == null)
            {
                return HttpNotFound();
            }
            return View(admin_user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admin_user admin_user = db.admin_user.Find(id);
            db.admin_user.Remove(admin_user);
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
