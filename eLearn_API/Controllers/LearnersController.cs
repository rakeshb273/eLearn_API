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
    public class LearnersController : ApiController
    {
        private eLearnEntities db = new eLearnEntities();

        // GET: api/Learners
        public IQueryable<Learner> GetLearners()
        {

            return db.Learners ;

        }

        // GET: api/Learners/5
        [ResponseType(typeof(Learner))]
        public IHttpActionResult GetLearner(int id)
        {
            Learner learner = db.Learners.Find(id);
            if (learner == null)
            {
                return NotFound();
            }

            return Ok(learner);
        }

        // PUT: api/Learners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLearner(int id, Learner learner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != learner.ID)
            {
                return BadRequest();
            }

            db.Entry(learner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearnerExists(learner))
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

        // POST: api/Learners
        [ResponseType(typeof(Learner))]
        public IHttpActionResult PostLearner(Learner learner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Learners.Add(learner);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = learner.ID }, learner);
        }

        // DELETE: api/Learners/5
        [ResponseType(typeof(Learner))]
        public IHttpActionResult DeleteLearner(int id)
        {
            Learner learner = db.Learners.Find(id);
            if (learner == null)
            {
                return NotFound();
            }
            learner.isActive = false;
            db.SaveChanges();

            return Ok(learner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LearnerExists(Learner learner)
        {
            return db.Learners.Count(e => e.Mobile == learner.Mobile) > 0;
        }
        [HttpGet]
        [Route("Search")]
        public IHttpActionResult Search(string learnerText)
        {
            var courses = db.Learners.Where(e => e.FirstName == learnerText || e.LastName == learnerText || e.Mobile == learnerText || e.Email == learnerText || learnerText == null);
            if (courses == null)
            {
                return NotFound();
            }

            return Ok(courses);

        }
    }
}