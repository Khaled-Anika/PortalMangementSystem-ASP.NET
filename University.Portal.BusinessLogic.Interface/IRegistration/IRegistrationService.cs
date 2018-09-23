using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.Interface.IBaseCrud;
using University.Portal.Entites.CourseEntites;
using University.Portal.Entites.RegistrationEntites;
using University.Portal.Entites.StudentEntites;

namespace University.Portal.BusinessLogic.Interface.IRegistration
{
    public interface IRegistrationService:IBaseService<CourseRegistration>
    {
        //Return Per Semeister Course
        IEnumerable<CourseRegistration> GetByStudentAndCourse(string studentID, int SemisterID);

        //Return All Course Semester Wise
        IEnumerable<CourseRegistration> GetALLCoursesByStudentId(string studentId);

        //Get ALL Student Present In This Course Current Semester
        IEnumerable<CourseRegistration> GetStudentsByCourseId(int CourseID, int SemisterID);

        //Get All The Student Per Semester
        IEnumerable<CourseRegistration> GetAllStudentBYSemester(int SemisterID);

        //Get All The Student Per Semester
        IEnumerable<CourseComplete> GetAllStudentBYSemester_CourseComplete(int SemisterID);


        //
        bool AddCourseRegister(int CourseID, string StudentID, int semisterID);



    }
}
