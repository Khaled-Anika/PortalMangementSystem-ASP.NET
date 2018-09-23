using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University.Portal.Entites.DepartmentEntites;
using University.Portal.Entites.DegreeEntities;
using University.Portal.Entites.SemesterEntities;

namespace University.Portal.Application.Models
{
    public class StudentDeptDegModel
    {
        public List<Department> departments { get; set; }
        public List<Degree> degrees { get; set; }
        public List<Semester> semesters { get; set; }
    }
}