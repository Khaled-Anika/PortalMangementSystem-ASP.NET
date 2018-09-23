using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.BaseCrud_Service;
using University.Portal.BusinessLogic.Interface.ISemester;
using University.Portal.Entites.SemesterEntities;

namespace University.Portal.BusinessLogic.Semester_Service
{
    public sealed class SemesterService: BaseCrudService<Semester>, ISemesterService
    {
        public SemesterService(DbContext context) : base(context) { }

        //ISemesterService Implement Here
        public bool DuplicateSemester(Semester semester)
        {
            return Context.Set<Semester>().Any(u => u.SemesterCode == semester.SemesterCode && u.year == semester.year);
        }

    }
}
