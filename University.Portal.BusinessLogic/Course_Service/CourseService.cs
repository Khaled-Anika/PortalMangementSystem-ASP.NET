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
    public sealed class CourseService: BaseCrudService<Course>, ICourseService
    {
        public CourseService(DbContext context) : base(context) { }


        //This method return List Of the Course Get By Credit No.
        public IEnumerable<Course> GetByCredit(int Credit)
        {
            return Context.Set<Course>().Where(C => C.Credit == Credit).ToList();
        }

        public bool DuplicateCourse(Course course)
        {
            return Context.Set<Course>().Any(u => u.CourseCode == course.CourseCode || u.CourseName == course.CourseName);
        }
    }
}
