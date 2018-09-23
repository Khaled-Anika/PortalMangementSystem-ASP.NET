using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.Interface.IBaseCrud;
using University.Portal.Entites.CourseEntites;

namespace University.Portal.BusinessLogic.Interface.ICourse
{
    public interface ICourseService:IBaseService<Course>
    {

        //Get Course By Credit
        IEnumerable<Course> GetByCredit(int Credit);
        bool DuplicateCourse(Course course);
    }
}
