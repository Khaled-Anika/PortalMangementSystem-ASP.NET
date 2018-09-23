using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University.Portal.Entites.CourseEntites;
using University.Portal.Entites.SemesterEntities;

namespace University.Portal.Application.Models
{
    public class CourseCompleteModel
    {
        public Semester semester { get; set; }
        public List<Course> courses { get; set; }
    }
}