using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eLearn_API.Models
{
    public class CourseModel
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public bool isActive { get; set; }
        public  List<CoursesTakensModel> CoursesTakens { get; set; }
    }
}