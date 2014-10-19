using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kit.Server.Models;

namespace Kit.Server.Controllers
{
    public class NomenclaturesController : Controller
    {
        private LabTypeKitDbContext db = new LabTypeKitDbContext();

        // GET: Nomenclatures
        public async Task<ActionResult> Index()
        {
            return View(await db.Nomenclatures.ToListAsync());
        }

        // GET: Nomenclatures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomenclature nomenclature = await db.Nomenclatures.FindAsync(id);
            if (nomenclature == null)
            {
                return HttpNotFound();
            }
            return View(nomenclature);
        }

        // GET: Nomenclatures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nomenclatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Version")] Nomenclature nomenclature)
        {
            if (ModelState.IsValid)
            {
                db.Nomenclatures.Add(nomenclature);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nomenclature);
        }

        // GET: Nomenclatures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomenclature nomenclature = await db.Nomenclatures.FindAsync(id);
            if (nomenclature == null)
            {
                return HttpNotFound();
            }
            return View(nomenclature);
        }

        // POST: Nomenclatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Version")] Nomenclature nomenclature)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomenclature).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nomenclature);
        }

        // GET: Nomenclatures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomenclature nomenclature = await db.Nomenclatures.FindAsync(id);
            if (nomenclature == null)
            {
                return HttpNotFound();
            }
            return View(nomenclature);
        }

        // POST: Nomenclatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Nomenclature nomenclature = await db.Nomenclatures.FindAsync(id);
            db.Nomenclatures.Remove(nomenclature);
            await db.SaveChangesAsync();
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
