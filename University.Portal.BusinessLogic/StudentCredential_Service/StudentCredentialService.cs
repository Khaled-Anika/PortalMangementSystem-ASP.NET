using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Portal.BusinessLogic.BaseCrud_Service;
using University.Portal.BusinessLogic.Interface.IStudentCredential;
using University.Portal.Entites.StudentEntites;

namespace University.Portal.BusinessLogic.StudentCredential_Service
{
    public class StudentCredentialService : BaseCrudService<StudentCredential>, IStudentCredentialService
    {
        public StudentCredentialService(DbContext Context) : base(Context)
        {
        }
    }
}
