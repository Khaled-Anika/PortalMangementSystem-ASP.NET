using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace University.Portal.Application
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Admin", action = "Students", id = UrlParameter.Optional }
            //);

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AdminCourseUpdate",
                url: "Admin/CourseUpdate/{id}",
                defaults: new
                {
                    controller = "Admin",
                    action = "CourseUpdate",
                }
            );

            routes.MapRoute(
                name: "AdminCourseComplete",
                url: "Admin/CourseComplete/{id}",
                defaults: new
                {
                    controller = "Admin",
                    action = "CourseComplete",
                }
            );

            routes.MapRoute(
                name: "AdminStudentDetails",
                url: "Admin/Students/{id}",
                defaults: new
                {
                    controller = "Admin",
                    action = "StudentDetails",
                }
            );

            routes.MapRoute(
               name: "AdminDepartmentDetails",
               url: "Admin/DepartmentDetails",
               defaults: new
               {
                   controller = "Admin",
                   action = "DepartmentDetails",
                   id = UrlParameter.Optional
               }
           );

            routes.MapRoute(
              name: "AdminCourseDetails",
              url: "Admin/CourseDetails",
              defaults: new
              {
                  controller = "Admin",
                  action = "CourseDetails",
                  id = UrlParameter.Optional
              }
          );


            routes.MapRoute(
              name: "AdminDegreeDetails",
              url: "Admin/DegreeDetails",
              defaults: new
              {
                  controller = "Admin",
                  action = "DegreeDetails",
                  id = UrlParameter.Optional
              }
          );

            routes.MapRoute(
               name: "AdminStudents",
               url: "Admin/Students",
               defaults: new
               {
                   controller = "Admin",
                   action = "Students",
                   id = UrlParameter.Optional
               }
           );

            routes.MapRoute(
               name: "AdminAddNewStudent",
               url: "Admin/AddStudent",
               defaults: new
               {
                   controller = "Admin",
                   action = "AddStudent",
                   id = UrlParameter.Optional
               }
           );

            routes.MapRoute(
               name: "AdminAddDepartment",
               url: "Admin/AddDepartment",
               defaults: new
               {
                   controller = "Admin",
                   action = "AddDepartment",
                   id = UrlParameter.Optional
               }
           );

            routes.MapRoute(
              name: "AdminAddCourse",
              url: "Admin/AddCourse",
              defaults: new
              {
                  controller = "Admin",
                  action = "AddCourse",
                  id = UrlParameter.Optional
              }
          );

            routes.MapRoute(
              name: "AdminAddDegree",
              url: "Admin/AddDegree",
              defaults: new
              {
                  controller = "Admin",
                  action = "AddDegree",
                  id = UrlParameter.Optional
              }
          );

            routes.MapRoute(
             name: "AdminAddSemester",
             url: "Admin/AddSemester",
             defaults: new
             {
                 controller = "Admin",
                 action = "AddSemester",
                 id = UrlParameter.Optional
             }
         );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
