using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Portal.BusinessLogic.Interface.ICourse;
using University.Portal.BusinessLogic.Interface.IRegistration;
using University.Portal.BusinessLogic.Interface.ISemester;
using University.Portal.BusinessLogic.Interface.IStudent;
using University.Portal.Entites.CourseEntites;
using University.Portal.Entites.DegreeEntities;
using University.Portal.Entites.RegistrationEntites;
using University.Portal.Entites.SemesterEntities;
using University.Portal.Entites.StudentEntites;
using University.Portal.Entites.VModel.Entites;

namespace University.Portal.Application.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private IStudentService _Student;
        private ICourseService _Course;
        private IRegistrationService _Registration;
        ISemesterService _ISemister;
        ICourseCompleteService courseCompleteService;
        private DbContext _Context;

        string studentID;

        public StudentController(ICourseCompleteService courseCompleteService,IStudentService student, DbContext context, ICourseService course, IRegistrationService registrationService, ISemesterService ISemester)
        {
            _Student = student;
            _Context = context;
            _Course = course;
            _Registration = registrationService;
            this.courseCompleteService = courseCompleteService;
            _ISemister = ISemester;


            if (System.Web.HttpContext.Current.Session["UserId"] != null)
            {
                studentID = (string)System.Web.HttpContext.Current.Session["UserId"];
            }

            else
            {
                RedirectToAction("Index", "Account");

            }


            //  studentID = "15-28964-1";



        }


        // GET: Student Profile
        public ActionResult Index()
        {


            var student = _Student.GetBy_StudentID(studentID);


            return View(student);
        }



        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }




        [HttpPost]
        public ActionResult ChangePassword(VChangePassword Change)
        {

            if (ModelState.IsValid)
            {

                var Result = _Student.ChangePassword(Change, studentID);

                if (Result == true)
                {

                    // TempData["msg"] = "<script>alert('Change Password Sccessfully');</script>";

                    ViewBag.msg = "<script>alert('Change Password Sccessfully');</script>";



                    return RedirectToAction("Index");
                }

                else
                {
                    ModelState.AddModelError("Wrong", "Current Password Incorrect");
                }



            }

            return View(Change);
        }


        [HttpGet]
        public ActionResult CourseRegistration()
        {
            var CurrentSemester = _Context.Set<Semester>().OrderByDescending(x => x.SemesterId).Take(1).FirstOrDefault();


            var courseList = _Context.Set<Course>().Where(x => !(_Context.Set<CourseComplete>().Any(c => c.CourseId == x.CourseId && c.StudentId == studentID))).ToList();
            //var courseList = _Course.GetAll();


            var registerdcourses = _Registration.GetByStudentAndCourse(studentID, CurrentSemester.SemesterId).Select(i => i.CourseId).ToList();
            ViewBag.registerdcourses = registerdcourses;

            return View(courseList);


        }



        [HttpPost]
        public JsonResult AddCourse(int CourseID)
        {


            var CurrentSemester = _Context.Set<Semester>().OrderByDescending(x => x.SemesterId).Take(1).FirstOrDefault();

            var Result = _Registration.AddCourseRegister(CourseID, studentID, CurrentSemester.SemesterId);

            if (Result == true)
            {
                return Json("Course Add Successfull", JsonRequestBehavior.AllowGet);
            }

            else
            {

                return Json("Failled", JsonRequestBehavior.AllowGet);

            }

        }


        [HttpGet]
        public ActionResult CourseCurriculam()
        {

            return View();

        }

        public ActionResult CourseDataLoad()
        {
            var data = _Course.GetAll().ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult CourseComplete()
        {
            // var CompleteList = _Context.Set<CourseComplete>().Include("Courses").Include("Semesters").Where(x => x.StudentId == studentID).ToList();

            // var registeredCourses = _Registration.GetALLCoursesByStudentId(studentID).ToList();
            var registeredCourses = _Context.Set<CourseComplete>().Where(x => x.StudentId == studentID).ToList();

            var uniqueSem = registeredCourses.Select(x => x.SemesterId).Distinct().ToList();

            List<VCourseCompleteModel> completedCourses = new List<VCourseCompleteModel>();
            for (int i = 0; i < uniqueSem.Count; i++)
            {
                var sem = _ISemister.Get(uniqueSem[i]);
                List<Course> courses = new List<Course>();
                List<CourseComplete> list = _Context.Set<CourseComplete>().Where(x => x.StudentId == studentID).ToList();
                //List<CourseComplete> list = courseCompleteService.GetCourseByStudentAndSemester(studentID, uniqueSem[i]);



                for (int j = 0; j < list.Count; j++)
                {
                    courses.Add(_Course.Get(list[j].CourseId));
                }

                VCourseCompleteModel model = new VCourseCompleteModel();
                model.semester = sem;
                model.courses = courses;

                completedCourses.Add(model);

            }
            return View(completedCourses);

        }



        //[HttpGet]
        //public ActionResult RegisterCourse()
        //{

        //    var CurrentSemester = _Context.Set<CourseRegistration>().Where(x => x.StudentId == studentID).OrderByDescending(x => x.SemesterId).Take(1).FirstOrDefault();

        //    var AllCourse = _Context.Set<CourseRegistration>().Include("Semesters").Include("Courses").Where(x => x.StudentId == studentID && x.SemesterId == CurrentSemester.SemesterId).ToList();

        //    return View(AllCourse);
        //}

        [HttpGet]
        public ActionResult RegisterCourseGet()
        {
            //var studentExist = _Context.Set<CourseComplete>().Where(x => x.StudentId == studentID).ToList();
            //if(studentExist.Count==0)
            //{

            //}
            //else
            //{

            //}

            var CurrentSemester = _Context.Set<CourseRegistration>().Where(x => x.StudentId == studentID).OrderByDescending(x => x.SemesterId).Take(1).FirstOrDefault();

            var AllCourse = _Context.Set<CourseRegistration>().Include("Semesters").Include("Courses").Where(x => x.StudentId == studentID && x.SemesterId == CurrentSemester.SemesterId).ToList();

            return PartialView("_RegisterCoursePartialView", AllCourse);
        }


        [HttpPost]
        public JsonResult RegisterCourseAdd(List<CourseComplete> Coures)
        {
            string m = "";
            if (Coures != null)
            {
                // Coures = new List<CourseComplete>();

                foreach (var item in Coures)
                {
                    _Context.Set<CourseComplete>().Add(item);

                }

                _Context.SaveChanges();

                m = "Registration Complete";
            }

            else
            {
                m = "problem";
            }

            return Json(m, JsonRequestBehavior.AllowGet);

        }



    }
}