using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Kit.Server.Models;

namespace Kit.Server.Controllers
{
    [Authorize]
    public class PoolsController : ApiController
    {
        private LabTypeKitDbContext db = new LabTypeKitDbContext();

        // GET: api/Pools
        [ResponseType(typeof(IEnumerable<KitPool>))]
        public IEnumerable<KitPool> GetKitPools()
        {
            var kp = db.KitPools;
            var kpl = kp.ToArray();
            return kpl;
        }

        // GET: api/Pools/5
        [ResponseType(typeof(KitPool))]
        public async Task<IHttpActionResult> GetKitPool(int id)
        {
            KitPool kitPool = await db.KitPools.FindAsync(id);
            if (kitPool == null)
            {
                return NotFound();
            }

            return Ok(kitPool);
        }

        // PUT: api/Pools/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKitPool(int id, KitPool kitPool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kitPool.Id)
            {
                return BadRequest();
            }

            db.Entry(kitPool).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitPoolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Pools
        [ResponseType(typeof(KitPool))]
        public async Task<IHttpActionResult> PostKitPool(KitPool kitPool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KitPools.Add(kitPool);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = kitPool.Id }, kitPool);
        }

        // DELETE: api/Pools/5
        [ResponseType(typeof(KitPool))]
        public async Task<IHttpActionResult> DeleteKitPool(int id)
        {
            KitPool kitPool = await db.KitPools.FindAsync(id);
            if (kitPool == null)
            {
                return NotFound();
            }

            db.KitPools.Remove(kitPool);
            await db.SaveChangesAsync();

            return Ok(kitPool);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KitPoolExists(int id)
        {
            return db.KitPools.Count(e => e.Id == id) > 0;
        }
    }
}