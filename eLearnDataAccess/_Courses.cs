using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearnDataAccess
{
   public class _Courses
    {
        static eLearnEntities el = new eLearnEntities();

        public static List<Courses> getCourses()
        {
            List<Courses> _courses = new List<Courses>();
            _courses = el.Courses.ToList();
            return _courses;
        }
        public static List<Courses> getCourses(int id)
        {
            List<Courses> _courses = new List<Courses>();
            _courses = el.Courses.Where(x => x.ID == id).ToList();
            return _courses;
        }
        public static void addCourse(Courses course)
        {
            try
            {
                el.Courses.Add(course);
                el.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void removeLearner(int CTID )
        {
            try
            {
                var ct = el.CoursesTakens.Where(x => x.ID == CTID).FirstOrDefault();
                el.CoursesTakens.Remove(ct);
                el.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }
        public static void UpdateCourse(int id, Courses course)
        {
            Courses _course = el.Courses.Where(x => x.ID == id).FirstOrDefault();
            _course.StartDate = course.StartDate;
            _course.EndDate = course.EndDate;
            _course.Description = course.Description;
            _course.CourseName = course.CourseName;
            el.SaveChanges();
        }

        public static void removeCourse(int id)
        {
            Courses _course = el.Courses.Where(x => x.ID == id).FirstOrDefault();
            _course.isActive = false;
            el.SaveChanges();
        }

        public static List<string> getLearners(int courseID)
        {
            List<string> _Learners = new List<string>();
            //var a= el.CoursesTakens.Where(x => x.CourseID == courseID).Select(x => new CoursesTaken { ID = x.LearnerID).ToList();

            return _Learners;
        }
    }
}

