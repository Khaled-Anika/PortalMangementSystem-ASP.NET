using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.Entites.DegreeEntities;
using University.Portal.Entites.DepartmentEntites;
using University.Portal.Entites.SemesterEntities;

namespace University.Portal.Entites.StudentEntites
{
    public class Student
    {
        [Key]

        public int Id { get; set; }
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [ForeignKey("Semester")]
        public int JoiningBatch { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("Degree")]
        public int DegreeId { get; set; }

        //[NotMapped]
        //public IEnumerable<Semester> semesters { get; set; }
        //[NotMapped]
        //public IEnumerable<Department> departments { get; set; }
        //[NotMapped]
        //public IEnumerable<Degree> degrees { get; set; }
        public Semester Semester { get; set; }
        public Department Department { get; set; }
        public Degree Degree { get; set; }
    }
}
