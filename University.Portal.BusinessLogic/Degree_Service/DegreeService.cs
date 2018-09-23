using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.BaseCrud_Service;
using University.Portal.BusinessLogic.Interface.IBaseCrud;
using University.Portal.BusinessLogic.Interface.IDegree;
using University.Portal.Entites.DegreeEntities;

namespace University.Portal.BusinessLogic.Degree_Service
{
    public sealed class DegreeService : BaseCrudService<Degree>, IDegreeService
    {
        public DegreeService(DbContext context) : base(context) { }

        public bool DuplicateDegree(Degree degree)
        {
            return Context.Set<Degree>().Any(u => u.DegreeName == degree.DegreeName);
        }
    }
}
