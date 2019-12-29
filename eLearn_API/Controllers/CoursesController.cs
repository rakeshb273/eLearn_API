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
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {
        private eLearnEntities db = new eLearnEntities();

        // GET: api/Courses
        public IQueryable<Courses> GetCourses()
        {
            return db.Courses;
        }

        // GET: api/Courses/5
        [ResponseType(typeof(Courses))]
        public IHttpActionResult GetCourses(int id)
        {
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return NotFound();
            }

            return Ok(courses);
        }

        // PUT: api/Courses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourses(int id, Courses courses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courses.ID)
            {
                return BadRequest();
            }

            db.Entry(courses).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursesExists(courses))
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

        // POST: api/Courses
        [ResponseType(typeof(Courses))]
        public IHttpActionResult PostCourses(Courses courses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(courses);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = courses.ID }, courses);
        }

        // DELETE: api/Courses/5
        [ResponseType(typeof(Courses))]
        public IHttpActionResult DeleteCourses(int id)
        {
            Courses courses = db.Courses.Find(id);
            if (courses == null)
            {
                return NotFound();
            }

            courses.isActive = false;
            db.SaveChanges();

            return Ok(courses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoursesExists(Courses course)
        {
            return db.Courses.Count(e => e.CourseCode == course.CourseCode || e.CourseName==course.CourseName) > 0;
        }

        [HttpGet]
        [Route("Search")]
        public IHttpActionResult Search([FromBody]SearchCourse course_S)
        {
            var courses = db.Courses.Where(e => e.CourseCode == course_S.name_S || e.CourseName == course_S.name_S || e.StartDate>= course_S.date_S || e.EndDate <= course_S.date_S || course_S.date_S==null);
            if (courses == null)
            {
                return NotFound();
            }

            return Ok(courses);

        }
    }
}