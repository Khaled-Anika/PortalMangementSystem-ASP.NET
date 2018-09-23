using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Portal.Entites.CourseEntites
{
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }
        public int Credit { get; set; }
        //public int DepartmentId { get; set; }
    }
}
