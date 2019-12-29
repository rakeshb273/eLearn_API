using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearn.Model
{
    class CoursesModel
    {

        public int ID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }

        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isActive { get; set; }
    }
}
