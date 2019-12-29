using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLearnDataAccess;

namespace eLearnDataAccess
{
    public class _Learners
    {
           private eLearnEntities db = new eLearnEntities();
        //public async List<Learner> GetLearners()
        //{
        //    Task t = new Task();
        //    return(await db.Learners.Select(x => new { x.FirstName, x.LastName, x.DOB, x.Email, x.Gender, x.isActive, x.CoursesTakens }).ToList())
      //  var a = db.Learners.Select(x => new { x.ID, x.FirstName, x.LastName, x.DOB, x.Email, x.Gender, x.isActive, x.ProfileImage, x.CoursesTakens }).ToList();
        //}
    }
}
