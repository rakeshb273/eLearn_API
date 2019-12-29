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
using eLearnDataAccess;

namespace eLearn_API.Controllers
{
    public class CoursesTakensController : ApiController
    {
        private eLearnEntities db = new eLearnEntities();

        // GET: api/CoursesTakens
        public IQueryable<CoursesTaken> GetCoursesTakens()
        {
            return db.CoursesTakens;
        }

        // GET: api/CoursesTakens/5
        [ResponseType(typeof(CoursesTaken))]
        public IHttpActionResult GetCoursesTaken(int id)
        {
            CoursesTaken coursesTaken = db.CoursesTakens.Find(id);
            if (coursesTaken == null)
            {
                return NotFound();
            }

            return Ok(coursesTaken);
        }

        // PUT: api/CoursesTakens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCoursesTaken(int id, CoursesTaken coursesTaken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coursesTaken.ID)
            {
                return BadRequest();
            }

            db.Entry(coursesTaken).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursesTakenExists(id))
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

        // POST: api/CoursesTakens
        [ResponseType(typeof(CoursesTaken))]
        public IHttpActionResult PostCoursesTaken(CoursesTaken coursesTaken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CoursesTakens.Add(coursesTaken);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coursesTaken.ID }, coursesTaken);
        }

        // DELETE: api/CoursesTakens/5
        [ResponseType(typeof(CoursesTaken))]
        public IHttpActionResult DeleteCoursesTaken(int id)
        {
            CoursesTaken coursesTaken = db.CoursesTakens.Find(id);
            if (coursesTaken == null)
            {
                return NotFound();
            }

            db.CoursesTakens.Remove(coursesTaken);
            db.SaveChanges();

            return Ok(coursesTaken);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoursesTakenExists(int id)
        {
            return db.CoursesTakens.Count(e => e.ID == id) > 0;
        }
    }
}