using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kit.Server.Models;

namespace Kit.Server.Views
{
    public class ProbesController : Controller
    {
        private LabTypeKitDbContext db = new LabTypeKitDbContext();

        // GET: Probes
        public ActionResult Index()
        {
            return View(db.Probes.ToList());
        }

        // GET: Probes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Probe probe = db.Probes.Find(id);
            if (probe == null)
            {
                return HttpNotFound();
            }
            return View(probe);
        }

        // GET: Probes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Probes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Probe probe)
        {
            if (ModelState.IsValid)
            {
                db.Probes.Add(probe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(probe);
        }

        // GET: Probes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Probe probe = db.Probes.Find(id);
            if (probe == null)
            {
                return HttpNotFound();
            }
            return View(probe);
        }

        // POST: Probes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Probe probe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(probe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(probe);
        }

        // GET: Probes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Probe probe = db.Probes.Find(id);
            if (probe == null)
            {
                return HttpNotFound();
            }
            return View(probe);
        }

        // POST: Probes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Probe probe = db.Probes.Find(id);
            db.Probes.Remove(probe);
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
