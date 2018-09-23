using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.Interface.IBaseCrud;
using University.Portal.Entites.StudentEntites;
using University.Portal.Entites.VModel.Entites;

namespace University.Portal.BusinessLogic.Interface.IStudent
{
    public interface IStudentService:IBaseService<Student>
    {
        //This method return List Of the Course Get By Credit No.
        Student GetBy_StudentID(string StudentID);
        bool DuplicateStudent(Student student);
        bool ChangePassword(VChangePassword Change, string StudentID);
        IEnumerable<Student> GetAllWithDeptAndDegree();
        Student GetByStudentID(string StudentID);
        bool StudentUpdate(Student entity, string id);
    }
}
