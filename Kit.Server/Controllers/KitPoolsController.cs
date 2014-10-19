using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kit.Server.Models;

namespace Kit.Server.Controllers
{
    public class KitPoolsController : Controller
    {
        private LabTypeKitDbContext db = new LabTypeKitDbContext();

        // GET: KitPools
        [HttpGet]
        public ActionResult Index()
        {
            var kpl = db.KitPools.ToList();
            return View(kpl);
        }

        // GET: KitPools/MyView/5
        [HttpGet]
        public ActionResult MyView(int? x)
        {
            var kpl = db.KitPools.ToList();
            return View(kpl);
        }

        // GET: KitPools/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KitPool kitPool = db.KitPools.Find(id);
            if (kitPool == null)
            {
                return HttpNotFound();
            }
            return View(kitPool);
        }

        // GET: KitPools/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: KitPools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KitName")] KitPool kitPool)
        {
            if (ModelState.IsValid)
            {
                db.KitPools.Add(kitPool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kitPool);
        }

        // GET: KitPools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KitPool kitPool = db.KitPools.Find(id);
            if (kitPool == null)
            {
                return HttpNotFound();
            }
            return View(kitPool);
        }

        // POST: KitPools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KitName")] KitPool kitPool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kitPool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kitPool);
        }

        // GET: KitPools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KitPool kitPool = db.KitPools.Find(id);
            if (kitPool == null)
            {
                return HttpNotFound();
            }
            return View(kitPool);
        }

        // POST: KitPools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KitPool kitPool = db.KitPools.Find(id);
            db.KitPools.Remove(kitPool);
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
