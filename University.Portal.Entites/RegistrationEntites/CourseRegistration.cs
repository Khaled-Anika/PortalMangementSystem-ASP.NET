using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.Entites.CourseEntites;
using University.Portal.Entites.SemesterEntities;
using University.Portal.Entites.StudentEntites;

namespace University.Portal.Entites.RegistrationEntites
{
    public class CourseRegistration
    {
        [Key]
        public int CourseRegistrationId { get; set; }
        public string StudentId { get; set; }

        [ForeignKey("Semesters")]
        public int SemesterId { get; set; }

        [ForeignKey("Courses")]
        public int CourseId { get; set; }


        public Course Courses { get; set; }

        public Semester Semesters { get; set; }
    }
}
