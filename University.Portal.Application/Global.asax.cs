using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using University.Portal.BusinessLogic.BaseCrud_Service;
using University.Portal.BusinessLogic.Course_Service;
using University.Portal.BusinessLogic.Degree_Service;
using University.Portal.BusinessLogic.Department_Service;
using University.Portal.BusinessLogic.Interface.ICourse;
using University.Portal.BusinessLogic.Interface.IDegree;
using University.Portal.BusinessLogic.Interface.IDepartment;
using University.Portal.BusinessLogic.Interface.IRegistration;
using University.Portal.BusinessLogic.Interface.ISemester;
using University.Portal.BusinessLogic.Interface.IStudent;
using University.Portal.BusinessLogic.Interface.IStudentCredential;
using University.Portal.BusinessLogic.Registration_Service;
using University.Portal.BusinessLogic.Semester_Service;
using University.Portal.BusinessLogic.Student_Service;
using University.Portal.BusinessLogic.StudentCredential_Service;
using University.Portal.Infrastructure;

namespace University.Portal.Application
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);



            //AutoFac Config
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterSource(new ViewRegistrationSource());

            // manual registration of types;
            builder.RegisterType<UMSDbContext>().As<DbContext>();

            builder.RegisterType<StudentService>().As<IStudentService>();
            builder.RegisterType<CourseService>().As<ICourseService>();
            builder.RegisterType<DegreeService>().As<IDegreeService>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
            builder.RegisterType<RegistrationService>().As<IRegistrationService>();
            builder.RegisterType<SemesterService>().As<ISemesterService>();
            builder.RegisterType<StudentCredentialService>().As<IStudentCredentialService>();
            builder.RegisterType<CourseCompleteService>().As<ICourseCompleteService>();





            //Container Pass
            var container = builder.Build();

            //Mvc Register
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
           // UMSDbContext db = new UMSDbContext();
        }
    }
}
