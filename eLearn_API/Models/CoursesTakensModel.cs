using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eLearn_API.Models
{
    public class CoursesTakensModel
    {
        public int id;
        public Nullable<int> CourseID;
        public Nullable<int> LearnerID;
        public string CourseName { get; set; }
        public string LearnerName { get; set; }
    }
}