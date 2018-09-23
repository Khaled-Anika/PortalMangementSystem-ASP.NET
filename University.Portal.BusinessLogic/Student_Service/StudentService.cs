using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.BaseCrud_Service;
using University.Portal.BusinessLogic.Interface.IBaseCrud;
using University.Portal.BusinessLogic.Interface.IStudent;
using University.Portal.Entites.StudentEntites;
using University.Portal.Entites.VModel.Entites;

namespace University.Portal.BusinessLogic.Student_Service
{
    public sealed class StudentService : BaseCrudService<Student>, IStudentService
    {

        public StudentService(DbContext context) : base(context) { }


        //Get Student Details By Student ID
        public Student GetBy_StudentID(string StudentID)
        {
            //Here Context Protected from Base Crud Operation
            return Context.Set<Student>().Include("Department").Include("Degree").Include("Semester").Where(x => x.StudentId == StudentID).SingleOrDefault();
        }

        public Student GetByStudentID(string StudentID)
        {
            return Context.Set<Student>().Where(x => x.StudentId == StudentID).SingleOrDefault();
        }

        public IEnumerable<Student> GetAllWithDeptAndDegree()
        {
            //Here Context Protected from Base Crud Operation
            return Context.Set<Student>().Include("Department").Include("Degree").Include("Semester").ToList();;
        }

        public bool DuplicateStudent(Student student)
        {
            return Context.Set<Student>().Any(u => u.StudentId == student.StudentId);
        }

        public bool ChangePassword(VChangePassword Change, string StudentID)
        {
            try
            {
                var student = Context.Set<StudentCredential>().Where(x => x.StudentId == StudentID && x.Password == Change.CurrentPassword).FirstOrDefault();


                if (student != null)
                {


                    student.Password = Change.NewPassword;
                    //Single Field Update
                    Context.Configuration.ValidateOnSaveEnabled = false;

                    Context.SaveChanges();

                    return true;


                }

                else
                {
                    return false;
                }


            }

            catch (Exception)
            {

                return false;
            }


        }

        public bool StudentUpdate(Student entity, string id)
        {
            //Student student = Context.Set<Student>().SingleOrDefault(b => b.Id == entity.Id);

            //student.StudentId = entity.StudentId;
            //student.FirstName = entity.FirstName;
            //student.MiddleName = entity.MiddleName;
            //student.LastName = entity.LastName;
            //student.JoiningBatch = entity.JoiningBatch;
            //student.DegreeId = entity.DegreeId;
            //student.DepartmentId = entity.DepartmentId;

            //Context.SaveChanges();

            //return true;

            try
            {
                Student student = GetByStudentID(id);
                if (student != null)
                {
                    Context.Entry(student).CurrentValues.SetValues(entity);
                    Context.Entry(student).State = EntityState.Modified;
                    Context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

    }
}
