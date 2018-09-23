using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University.Portal.Entites.SemesterEntities;

namespace University.Portal.Application.Models
{
    public class StudentDetailsModel
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Semester JoiningBatch { get; set; }

        public string DepartmentName { get; set; }
        public string DegreeName { get; set; }

        public IEnumerable<CourseCompleteModel> semesters { get; set; }
    }
}