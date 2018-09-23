using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.BaseCrud_Service;
using University.Portal.BusinessLogic.Interface.IRegistration;
using University.Portal.Entites.CourseEntites;
using University.Portal.Entites.RegistrationEntites;

namespace University.Portal.BusinessLogic.Registration_Service
{
    public sealed class RegistrationService : BaseCrudService<CourseRegistration>, IRegistrationService
    {

        public RegistrationService(DbContext context) : base(context) { }

        public bool AddCourseRegister(int CourseID, string StudentID, int semisterID)
        {
            try
            {
                var check = Context.Set<CourseRegistration>().Where(x => x.StudentId == StudentID && x.SemesterId == semisterID && x.CourseId == CourseID).FirstOrDefault();
                if (check != null)
                {
                    Context.Set<CourseRegistration>().Remove(check);
                    Context.SaveChanges();

                    return true;
                }

                else
                {
                    CourseRegistration c = new CourseRegistration();
                    c.CourseId = CourseID;
                    c.SemesterId = semisterID;
                    c.StudentId = StudentID;
                    Context.Set<CourseRegistration>().Add(c);
                    Context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return true;
            }
        }


        //Return All Courses Semester Wise
        public IEnumerable<CourseRegistration> GetALLCoursesByStudentId(string studentId)
        {
            try
            {
                var CourseList = Context.Set<CourseRegistration>().Where(x => x.StudentId == studentId).ToList();

                return CourseList;
            }
            catch (Exception)
            {

                return null;
            }

        }

        //Get All The Student Per Semester
        public IEnumerable<CourseRegistration> GetAllStudentBYSemester(int SemisterID)
        {
            try
            {
                var AllSrudentPerSemester = Context.Set<CourseRegistration>().Where(x => x.SemesterId == SemisterID).ToList();
                return AllSrudentPerSemester;
            }
            catch (Exception)
            {

                return null;
            }
        }


        //New Method Add
        public IEnumerable<CourseComplete> GetAllStudentBYSemester_CourseComplete(int SemisterID)
        {

            try
            {
                var AllSrudentPerSemester = Context.Set<CourseComplete>().Where(x => x.SemesterId == SemisterID).ToList();
                return AllSrudentPerSemester;
            }
            catch (Exception)
            {

                return null;
            }
        }



        //Per Semester Course
        public IEnumerable<CourseRegistration> GetByStudentAndCourse(string studentID, int SemisterID)
        {
            try
            {
                var PerSemesterCourse = Context.Set<CourseRegistration>().Where(x => x.StudentId == studentID && x.SemesterId == SemisterID).ToList();
                return PerSemesterCourse;
            }
            catch (Exception)
            {

                return null;
            }
        }


        //All Student Present In The Single Course In the Current Semester
        public IEnumerable<CourseRegistration> GetStudentsByCourseId(int CourseID, int SemisterID)
        {
            try
            {
                var ALLStudentByCourseID = Context.Set<CourseRegistration>().Where(x => x.CourseId == CourseID && x.SemesterId == SemisterID).ToList();
                return ALLStudentByCourseID;
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}
