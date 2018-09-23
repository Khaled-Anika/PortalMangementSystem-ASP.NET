using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.Interface.IBaseCrud;
using University.Portal.Entites.DepartmentEntites;

namespace University.Portal.BusinessLogic.Interface.IDepartment
{
    public interface IDepartmentService:IBaseService<Department>
    {
        bool DuplicateDepartment(Department department);
    }
}
