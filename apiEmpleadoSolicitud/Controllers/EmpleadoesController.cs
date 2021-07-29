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
using apiEmpleadoSolicitud.Models;

namespace apiEmpleadoSolicitud.Controllers
{
    public class EmpleadoesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Empleadoes
        public IQueryable<Empleado> GetEmpleado()
        {
            return db.Empleado;
        }

        [ResponseType(typeof(Empleado))]
        public IHttpActionResult GetEmpleado(decimal id)
        {
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            return Ok(empleado.nombre);
        }

        // PUT: api/Empleadoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleado(decimal id, Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleado.id)
            {
                return BadRequest();
            }

            db.Entry(empleado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/Empleadoes
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult PostEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Empleado.Add(empleado);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmpleadoExists(empleado.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = empleado.id }, empleado);
        }

        // DELETE: api/Empleadoes/5
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult DeleteEmpleado(decimal id)
        {
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }

            db.Empleado.Remove(empleado);
            db.SaveChanges();

            return Ok(empleado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadoExists(decimal id)
        {
            return db.Empleado.Count(e => e.id == id) > 0;
        }
    }
}