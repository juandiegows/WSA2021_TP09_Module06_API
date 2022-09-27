using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WSA2021_TP09_Module06_API.Models;
using WSA2021_TP09_Module06_API.Models.Request;
using WSA2021_TP09_Module06_API.Models.Response;

namespace WSA2021_TP09_Module06_API.Controllers
{
    public class UsuariosController : ApiController
    {
        private SessaoMobileEntities db = new SessaoMobileEntities();

        // GET: api/Usuarios
        /// <summary>
        /// get a list of users
        /// </summary>
        /// <returns></returns>
        public IQueryable<Usuario> GetUsuario()
        {
            return db.Usuario;
        }
        /// <summary>
        /// allows the user to login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/auth")]
        public Response Login([FromBody] LoginRequest login)
        {
            var user = db.Usuario.FirstOrDefault(x => (x.email.ToLower().Equals(login.Username.ToLower()) || x.nome.ToLower().Equals(login.Username.ToLower()) && x.senha == login.Password));

            if (user == null)
            {
                return new Response
                {
                    Sucess = false,
                    Data = null,
                    Message = "user or password incorrecto"
                };
            }
            else
            {
                return new Response
                {
                    Sucess = false,
                    Data = user,
                    Message = "login success"
                };
            }

        }
        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.id)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuario.Add(usuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuario.id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuario.Remove(usuario);
            db.SaveChanges();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuario.Count(e => e.id == id) > 0;
        }
    }
}