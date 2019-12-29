using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearn.Entities.Models
{
    public class Courses
    {
        public int ID;
        public string CourseName;
        public string CourseCode;
        public string Description;
        public DateTime StartDate;
        public DateTime EndDate;
        public bool isActive;
        public string image;

    }
}
