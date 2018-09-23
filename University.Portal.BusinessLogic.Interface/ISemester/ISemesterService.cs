using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.Interface.IBaseCrud;
using University.Portal.Entites.SemesterEntities;

namespace University.Portal.BusinessLogic.Interface.ISemester
{
    public interface ISemesterService:IBaseService<Semester>
    {
        bool DuplicateSemester(Semester semester);
    }
}
