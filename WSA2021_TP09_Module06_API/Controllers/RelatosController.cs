using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WSA2021_TP09_Module06_API.Models;

namespace WSA2021_TP09_Module06_API.Controllers
{
    public class RelatosController : ApiController
    {
        private SessaoMobileEntities db = new SessaoMobileEntities();

        // GET: api/Relatos
        public IHttpActionResult GetRelatos()
        {
            return Ok(
                db.Relatos.Select(x=> new { x.id, x.imagem, x.latitude, x.longitude, x.relato, x.usuarioid, x.Usuario.nome,x.Usuario.telefone}).ToList() );
        }

        // GET: api/Relatos/5
        [ResponseType(typeof(Relatos))]
        public IHttpActionResult GetRelatos(int id)
        {
            Relatos relatos = db.Relatos.Find(id);
            if (relatos == null)
            {
                return NotFound();
            }

            return Ok(new { 
                relatos.id, 
                relatos.imagem, 
                relatos.latitude, 
                relatos.longitude, 
                relatos.relato, 
                relatos.usuarioid, 
                relatos.Usuario.nome });
        }

        // PUT: api/Relatos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRelatos(int id, Relatos relatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != relatos.id)
            {
                return BadRequest();
            }

            db.Entry(relatos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelatosExists(id))
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

        // POST: api/Relatos
        [ResponseType(typeof(Relatos))]
        public IHttpActionResult PostRelatos(Relatos relatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Relatos.Add(relatos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = relatos.id }, relatos);
        }

        // DELETE: api/Relatos/5
        [ResponseType(typeof(Relatos))]
        public IHttpActionResult DeleteRelatos(int id)
        {
            Relatos relatos = db.Relatos.Find(id);
            if (relatos == null)
            {
                return NotFound();
            }

            db.Relatos.Remove(relatos);
            db.SaveChanges();

            return Ok(relatos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RelatosExists(int id)
        {
            return db.Relatos.Count(e => e.id == id) > 0;
        }
    }
}