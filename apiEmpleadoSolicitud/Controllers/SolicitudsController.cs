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
using System.Data.Entity;

namespace apiEmpleadoSolicitud.Controllers
{
    public class SolicitudsController : ApiController
    {
        private Model1 db = new Model1();
       
        // GET: api/Solicituds
        public IQueryable<Solicitud> GetSolicitud()
        {
            
            return db.Solicitud;
        }

        // GET: api/Solicituds/5
        [ResponseType(typeof(Solicitud))]
        public IHttpActionResult GetSolicitud(decimal id)
        {
            Solicitud solicitud = db.Solicitud.Find(id);

            if (solicitud == null)
            {
                return NotFound();
            }

            return Ok(solicitud);
        }

        // PUT: api/Solicituds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSolicitud(decimal id, Solicitud solicitud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solicitud.id)
            {
                return BadRequest();
            }

            db.Entry(solicitud).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudExists(id))
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

        // POST: api/Solicituds
        [ResponseType(typeof(Solicitud))]
        public IHttpActionResult PostSolicitud(Solicitud solicitud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Solicitud.Add(solicitud);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SolicitudExists(solicitud.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = solicitud.id }, solicitud);
        }

        // DELETE: api/Solicituds/5
        [ResponseType(typeof(Solicitud))]
        public IHttpActionResult DeleteSolicitud(decimal id)
        {
            Solicitud solicitud = db.Solicitud.Find(id);
            if (solicitud == null)
            {
                return NotFound();
            }

            db.Solicitud.Remove(solicitud);
            db.SaveChanges();

            return Ok(solicitud);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SolicitudExists(decimal id)
        {
            return db.Solicitud.Count(e => e.id == id) > 0;
        }
    }
}