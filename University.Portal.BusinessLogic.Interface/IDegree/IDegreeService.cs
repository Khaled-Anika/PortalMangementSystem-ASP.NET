using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.Interface.IBaseCrud;
using University.Portal.Entites.DegreeEntities;

namespace University.Portal.BusinessLogic.Interface.IDegree
{
    public interface IDegreeService: IBaseService<Degree>
    {
        bool DuplicateDegree(Degree degree);
    }
}
