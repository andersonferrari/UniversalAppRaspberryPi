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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestesController : ApiController
    {
        private TesteDbContext db = new TesteDbContext();

        // GET: api/Testes
        public IQueryable<Teste> GetTestes()
        {
            return db.Testes;
        }

        // GET: api/Testes/5
        [ResponseType(typeof(Teste))]
        public async Task<IHttpActionResult> GetTeste(int id)
        {
            Teste teste = await db.Testes.FindAsync(id);
            if (teste == null)
            {
                return NotFound();
            }

            return Ok(teste);
        }

        // PUT: api/Testes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTeste(int id, Teste teste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teste.id)
            {
                return BadRequest();
            }

            db.Entry(teste).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TesteExists(id))
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

        // POST: api/Testes
        [ResponseType(typeof(Teste))]
        public async Task<IHttpActionResult> PostTeste(Teste teste)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Testes.Add(teste);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = teste.id }, teste);
        }

        // DELETE: api/Testes/5
        [ResponseType(typeof(Teste))]
        public async Task<IHttpActionResult> DeleteTeste(int id)
        {
            Teste teste = await db.Testes.FindAsync(id);
            if (teste == null)
            {
                return NotFound();
            }

            db.Testes.Remove(teste);
            await db.SaveChangesAsync();

            return Ok(teste);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TesteExists(int id)
        {
            return db.Testes.Count(e => e.id == id) > 0;
        }
    }
}