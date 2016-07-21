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
    public class RoleController : Controller
    {
        private posEntities db = new posEntities();

        // GET: /Role/
        public ActionResult Index()
        {
            return View(db.admin_role.ToList());
        }

        // GET: /Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin_role admin_role = db.admin_role.Find(id);
            if (admin_role == null)
            {
                return HttpNotFound();
            }
            return View(admin_role);
        }

        // GET: /Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="admin_role_id,role_name,role_description")] admin_role admin_role)
        {
            if (ModelState.IsValid)
            {
                db.admin_role.Add(admin_role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin_role);
        }

        // GET: /Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin_role admin_role = db.admin_role.Find(id);
            if (admin_role == null)
            {
                return HttpNotFound();
            }
            return View(admin_role);
        }

        // POST: /Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="admin_role_id,role_name,role_description")] admin_role admin_role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin_role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin_role);
        }

        // GET: /Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin_role admin_role = db.admin_role.Find(id);
            if (admin_role == null)
            {
                return HttpNotFound();
            }
            return View(admin_role);
        }

        // POST: /Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admin_role admin_role = db.admin_role.Find(id);
            db.admin_role.Remove(admin_role);
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
