using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.Entites.SemesterEntities;
using University.Portal.Entites.StudentEntites;

namespace University.Portal.Entites.CourseEntites
{
    public class CourseComplete
    {
        [Key]
        public int CourseCompleteId { get; set; }
        //[ForeignKey("Student")]
        public string StudentId { get; set; }
        //[ForeignKey("Courses")]
        public int CourseId { get; set; }
        //[ForeignKey("Semester")]
        public int SemesterId { get; set; }

        //public Student Student { get; set; }
        //public Course Course { get; set; }
        //public Semester Semester { get; set; }

    }
}
