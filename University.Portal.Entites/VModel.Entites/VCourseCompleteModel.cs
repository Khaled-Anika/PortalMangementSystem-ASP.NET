using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.Entites.CourseEntites;
using University.Portal.Entites.SemesterEntities;

namespace University.Portal.Entites.VModel.Entites
{
    public class VCourseCompleteModel
    {
        public Semester semester { get; set; }
        public List<Course> courses { get; set; }
    }
}
