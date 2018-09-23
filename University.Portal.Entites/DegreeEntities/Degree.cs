using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.Entites.DepartmentEntites;
using University.Portal.Entites.StudentEntites;

namespace University.Portal.Entites.DegreeEntities
{
    public class Degree
    {
        public int DegreeId { get; set; }
        public string DegreeName { get; set; }
        //[ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public List<Student> Students { get; set; }
        //public Department Department { get; set; }
        //[NotMapped]
        //public IEnumerable<Department> Departments { get; set; }
    }
}
