using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DATA.EF;

namespace StoreFrontLab.UI.MVC.Controllers
{
    public class UserRegistriesController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();

        // GET: UserRegistries
        public ActionResult Index()
        {
            return View(db.UserRegistries.ToList());
        }

        // GET: UserRegistries/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistry userRegistry = db.UserRegistries.Find(id);
            if (userRegistry == null)
            {
                return HttpNotFound();
            }
            return View(userRegistry);
        }

        // GET: UserRegistries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRegistries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,FirstName,LastName,EmailAddress")] UserRegistry userRegistry)
        {
            if (ModelState.IsValid)
            {
                db.UserRegistries.Add(userRegistry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userRegistry);
        }

        // GET: UserRegistries/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistry userRegistry = db.UserRegistries.Find(id);
            if (userRegistry == null)
            {
                return HttpNotFound();
            }
            return View(userRegistry);
        }

        // POST: UserRegistries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,EmailAddress")] UserRegistry userRegistry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRegistry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRegistry);
        }

        // GET: UserRegistries/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRegistry userRegistry = db.UserRegistries.Find(id);
            if (userRegistry == null)
            {
                return HttpNotFound();
            }
            return View(userRegistry);
        }

        // POST: UserRegistries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserRegistry userRegistry = db.UserRegistries.Find(id);
            db.UserRegistries.Remove(userRegistry);
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
