using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.Entites.StudentEntites;

namespace University.Portal.Entites.DepartmentEntites
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public List<Student> Students { get; set; }
    }
}
