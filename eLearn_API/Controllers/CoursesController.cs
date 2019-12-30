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
using eLearn_API.Models;




namespace eLearn_API.Controllers
{
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {
        private eLearnEntities db = new eLearnEntities();

        // GET: api/Courses
        public List<CourseModel> GetCourses()
        {
            List<CourseModel> allCourses = new List<CourseModel>();
            foreach(var course in db.Courses)
            {
                CourseModel cnow = new CourseModel();
                cnow.ID = course.ID;
                cnow.CourseCode = course.CourseCode;
                cnow.CourseName = course.CourseName;
                cnow.Description = course.Description;
                cnow.StartDate = course.StartDate;
                cnow.EndDate = course.EndDate;
                cnow.ID = course.ID;
                cnow.Image = course.Image;
                List<CoursesTakensModel> allCTs = new List<CoursesTakensModel>();
                foreach (var ct in course.CoursesTakens)
                {
                    CoursesTakensModel ctnow = new CoursesTakensModel();
                    ctnow.id = ct.ID;
                    ctnow.CourseID = ct.CourseID;
                    ctnow.LearnerID = ct.LearnerID;
                    ctnow.CourseName = ct.Courses.CourseName;
                    ctnow.LearnerName = ct.Learner.FirstName + " " + ct.Learner.LastName;
                    allCTs.Add(ctnow);
                }
                cnow.CoursesTakens = allCTs;
                allCourses.Add(cnow);

            }


            return allCourses;
        }

        // GET: api/Courses/5
        [ResponseType(typeof(Courses))]
        public IHttpActionResult GetCourses(int id)
        {
            Courses course = db.Courses.Find(id);
            CourseModel cnow = new CourseModel();
            cnow.ID = course.ID;
            cnow.CourseCode = course.CourseCode;
            cnow.CourseName = course.CourseName;
            cnow.Description = course.Description;
            cnow.StartDate = course.StartDate;
            cnow.EndDate = course.EndDate;
            cnow.ID = course.ID;
            cnow.Image = course.Image;
            List<CoursesTakensModel> allCTs = new List<CoursesTakensModel>();
            foreach (var ct in course.CoursesTakens)
            {
                CoursesTakensModel ctnow = new CoursesTakensModel();
                ctnow.id = ct.ID;
                ctnow.CourseID = ct.CourseID;
                ctnow.LearnerID = ct.LearnerID;
                ctnow.CourseName = ct.Courses.CourseName;
                ctnow.LearnerName = ct.Learner.FirstName + " " + ct.Learner.LastName;
                allCTs.Add(ctnow);
            }
            cnow.CoursesTakens = allCTs;
            if (course == null)
            {
                return NotFound();
            }

            return Ok(cnow);
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
                if (!CoursesExists(courses.CourseCode,courses.CourseName))
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
        public IHttpActionResult PostCourses([FromBody]CourseModel _course)
        {

            Courses course = new Courses();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!CoursesExists(_course.CourseName,_course.CourseCode))
            {
                course.CourseCode = _course.CourseCode;
                course.CourseName = _course.CourseName;
                course.StartDate = _course.StartDate;
                course.EndDate = _course.EndDate;
                course.Image = _course.Image;
                db.Courses.Add(course);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = course.ID }, course);
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

        

        [HttpGet]
        public bool isCoursesExists([FromUri]string CourseCode, [FromUri]string CourseName)
        {
            return CoursesExists(CourseCode, CourseName);
        }
        
       
        private bool CoursesExists(string CourseCode,string CourseName)
        {
            return db.Courses.Count(e => e.CourseCode == CourseCode || e.CourseName==CourseName) > 0;
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