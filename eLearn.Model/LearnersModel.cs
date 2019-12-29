using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearn.Model
{
    class LearnersModel
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Description { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }   
        public string ProfileImage { get; set; }
        public bool isActive { get; set; }
    }
}
