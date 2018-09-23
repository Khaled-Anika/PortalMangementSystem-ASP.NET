using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.BaseCrud_Service;
using University.Portal.BusinessLogic.Interface.IDepartment;
using University.Portal.Entites.DepartmentEntites;

namespace University.Portal.BusinessLogic.Department_Service
{
    public sealed class DepartmentService : BaseCrudService<Department>, IDepartmentService
    {
        public DepartmentService(DbContext context) : base(context) { }


        //IDepartmentService Interface Method Implement Here
        public bool DuplicateDepartment(Department department)
        {
            return Context.Set<Department>().Any(u => u.DepartmentName == department.DepartmentName);
        }

    }
}
