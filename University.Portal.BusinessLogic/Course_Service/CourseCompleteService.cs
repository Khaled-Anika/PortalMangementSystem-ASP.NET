using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.BaseCrud_Service;
using University.Portal.BusinessLogic.Interface.ICourse;
using University.Portal.Entites.CourseEntites;

namespace University.Portal.BusinessLogic.Course_Service
{
    public class CourseCompleteService : BaseCrudService<CourseComplete>, ICourseCompleteService
    {
        public CourseCompleteService(DbContext Context) : base(Context)
        {
        }

        public IEnumerable<CourseComplete> GetCourseByStudentAndSemester(string studentID, int SemisterID)
        {
            try
            {
                var PerSemesterCourse = Context.Set<CourseComplete>().Where(x => x.StudentId == studentID && x.SemesterId == SemisterID).ToList();
                return PerSemesterCourse;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
