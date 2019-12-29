using eLearn_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eLearnDataAccess;

namespace eLearn_API.Controllers
{
    public class TestController : ApiController
    {

        private eLearnEntities db = new eLearnEntities();

        List<test> Exam = new List<test>();
        TestController()
        {
            Exam.Add(new test{ID=1,fName="qd",lName="qw"});
            Exam.Add(new test { ID = 2, fName = "qd2", lName = "qw2" });
            Exam.Add(new test { ID = 3, fName = "qd3", lName = "qw3" });
        }

        //[Route("api/Test/GetCourses")]
        //[HttpGet]
        //public List<Courses> GetCourses()
        //{
        //    List<Courses> newc = new List<Courses>();
        //    newc = db.Courses.ToList();
        //    return newc;
        //}
        // GET: api/Test
        public IEnumerable<test> Get()
        {
            return Exam;
        }

        // GET: api/Test/5
        public test Get(int id)
        {
            return Exam.Where(x => x.ID == id).FirstOrDefault();
        }

        // POST: api/Test
        public void Post(test value)
        {
            Exam.Add(value);
        }
        [Route("api/Test/getTest")]
        [HttpGet]
        // GET: api/Test/getTest
        public List<string> GetTest( )
        {
            List<string> tstlst = new List<string>();

            tstlst.Add("qweqr");
            tstlst.Add("qwafeqr");
            tstlst.Add("sfsqweqr");
            return tstlst;

        }
        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
