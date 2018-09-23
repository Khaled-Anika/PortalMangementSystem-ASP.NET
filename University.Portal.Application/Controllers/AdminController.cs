using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using University.Portal.Infrastructure;
using University.Portal.BusinessLogic.Student_Service;
using University.Portal.Entites.StudentEntites;
using University.Portal.Entites.SemesterEntities;
using University.Portal.Entites.AdminEntites;
using University.Portal.BusinessLogic.Semester_Service;
using University.Portal.BusinessLogic.Course_Service;
using University.Portal.BusinessLogic.Interface.IStudent;
using University.Portal.BusinessLogic.Interface.ISemester;
using University.Portal.BusinessLogic.Interface.ICourse;
using University.Portal.Entites.CourseEntites;
using University.Portal.BusinessLogic.Interface.IDepartment;
using University.Portal.Entites.DepartmentEntites;
using University.Portal.Application.Models;
using University.Portal.Entites.DegreeEntities;
using University.Portal.BusinessLogic.Interface.IRegistration;
using University.Portal.Entites.RegistrationEntites;
using University.Portal.BusinessLogic.Interface.IDegree;
using FluentValidation.Results;
using University.Portal.BusinessLogic.Interface.IStudentCredential;

namespace University.Portal.Application.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        UMSDbContext db = new UMSDbContext();

        IStudentService studentService;
        ISemesterService semesterService;
        ICourseService courseService;
        IDepartmentService departmentService;
        IRegistrationService registrationService;
        IDegreeService degreeService;
        IStudentCredentialService credentialService;

        List<Department> departments = new List<Department>();
        List<Degree> degrees = new List<Degree>();

        int currentSemID;

        int adminID;

        public AdminController(IStudentCredentialService credentialService,IStudentService studentService, ISemesterService semesterService, ICourseService courseService,IDepartmentService departmentService, IRegistrationService registrationService, IDegreeService degreeService)
        {
            this.studentService = studentService;
            this.semesterService = semesterService;
            this.courseService = courseService;
            this.departmentService = departmentService;
            this.registrationService = registrationService;
            this.degreeService = degreeService;
            this.credentialService = credentialService;
        }


        public AdminController()
        {
            if (System.Web.HttpContext.Current.Session["AdminId"] != null)
            {
                adminID = (int)System.Web.HttpContext.Current.Session["AdminId"];
            }

            else
            {
                RedirectToAction("Login", "Account");

            }

        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StudentDetails(string id)
        {
            Student student = studentService.GetBy_StudentID(id);

            return View(student);
        }

        [HttpGet]
        public ActionResult CourseComplete(string id)
        {
            List<CourseRegistration> registeredCourses = registrationService.GetALLCoursesByStudentId(id).ToList();
            List<int> uniqueSem = registeredCourses.Select(x => x.SemesterId).Distinct().ToList();
            List<CourseCompleteModel> completedCourses = new List<CourseCompleteModel>();
            for (int i = 0; i < uniqueSem.Count; i++)
            {
                Semester sem = semesterService.Get(uniqueSem[i]);
                List<Course> courses = new List<Course>();

                List<CourseRegistration> list = registrationService.GetAllStudentBYSemester(uniqueSem[i]).ToList();
                for (int j = 0; j < list.Count; j++)
                {
                    courses.Add(courseService.Get(list[j].CourseId));
                }

                CourseCompleteModel model = new CourseCompleteModel();
                model.semester = sem;
                model.courses = courses;

                completedCourses.Add(model);

            }
            return View(completedCourses);
        }

        [HttpGet]
        public ActionResult Students()
        {
            var data = studentService.GetAllWithDeptAndDegree();
            //UMSDbContext db = new UMSDbContext();
            //db.Admins.ToList();
            return View(data);
        }

        public ActionResult StudentDataLoad()
        {
            // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
            
            var data = studentService.GetAllWithDeptAndDegree();
           
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddSemester()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSemester(Semester sem)
        {
            SemesterValidation val = new SemesterValidation();

            ValidationResult model = val.Validate(sem);

            if (model.IsValid)

            {
                if (!semesterService.DuplicateSemester(sem))
                {
                    semesterService.Insert(sem);
                    ViewBag.success = "Semester added successfully";
                }
                else
                {
                    ViewBag.success = "Semester already existed.";
                }

                return View();
            }

            else
            {
                foreach (ValidationFailure _error in model.Errors)
                {
                    ModelState.AddModelError(_error.PropertyName, _error.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            CourseValidation val = new CourseValidation();

            ValidationResult model = val.Validate(course);

            if (model.IsValid)

            {
                if (!courseService.DuplicateCourse(course))
                {
                    courseService.Insert(course);
                    ViewBag.success = "Course added successfully";
                    return RedirectToAction("CourseDetails");
                }
                else
                {
                    ViewBag.success = "Course already existed.";
                }

                return View();
            }

            else
            {
                foreach (ValidationFailure _error in model.Errors)
                {
                    ModelState.AddModelError(_error.PropertyName, _error.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult AddDegree()
        {
            ViewBag.Departments = departmentService.GetAll();

            return View();
        }

        [HttpPost]
        public ActionResult AddDegree(Degree degree)
        {
            DegreeValidation val = new DegreeValidation();

            ValidationResult model = val.Validate(degree);

            if (model.IsValid)

            {
                if (!degreeService.DuplicateDegree(degree))
                {
                    degreeService.Insert(degree);
                    ViewBag.success = "Degree added successfully";
                    return RedirectToAction("DegreeDetails");
                }
                else
                {
                    ViewBag.success = "Degree already existed.";
                }
                ViewBag.Departments = departmentService.GetAll();
                return View(degree);
            }

            else
            {
                foreach (ValidationFailure _error in model.Errors)
                {
                    ModelState.AddModelError(_error.PropertyName, _error.ErrorMessage);
                }
            }
            ViewBag.Departments = departmentService.GetAll();
            return View(degree);
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            DepartmentValidation val = new DepartmentValidation();

            ValidationResult model = val.Validate(department);

            if (model.IsValid)

            {
                if (!departmentService.DuplicateDepartment(department))
                {
                    departmentService.Insert(department);
                    ViewBag.success = "Department added successfully";
                    return RedirectToAction("DepartmentDetails");
                }
                else
                {
                    ViewBag.success = "Department already existed.";
                }

                return View();
            }

            else
            {
                foreach (ValidationFailure _error in model.Errors)
                {
                    ModelState.AddModelError(_error.PropertyName, _error.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult DepartmentDetails()
        {
            return View();
        }

        public ActionResult DepartmentDataLoad()
        {
            var data = departmentService.GetAll().ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UpdateDepartment(int? id)
        {
            Department department = departmentService.Get(id);
            return View(department);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {
            DepartmentValidation val = new DepartmentValidation();

            ValidationResult model = val.Validate(department);

            if (model.IsValid)

            {
                //if (!departmentService.DuplicateDepartment(department))
                //{
                    departmentService.Update(department, department.DepartmentId);
                    ViewBag.Success = "Department Updated successfully";
                    return RedirectToAction("DepartmentDetails");
                //}
                //else
                //{
                //    ViewBag.success = "Department already existed.";
                //    return View(department);
                //}
            }

            else
            {
                foreach (ValidationFailure _error in model.Errors)
                {
                    ModelState.AddModelError(_error.PropertyName, _error.ErrorMessage);
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult DegreeDetails()
        {
            return View();
        }

        public ActionResult DegreeDataLoad()
        {
            var data = degreeService.GetAll().ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UpdateDegree(int? id)
        {
            Degree degree = degreeService.Get(id);
            return View(degree);
        }

        [HttpPost]
        public ActionResult UpdateDegree(Degree degree)
        {
            DegreeValidation val = new DegreeValidation();

            ValidationResult model = val.Validate(degree);

            if (model.IsValid)

            {
                //if (!degreeService.DuplicateDegree(degree))
                //{
                    degreeService.Update(degree, degree.DegreeId);
                    ViewBag.Success = "Degree Updated successfully";
                    return RedirectToAction("DegreeDetails");
                //}
                //else
                //{
                //    ViewBag.success = "Degree already existed.";
                //}
                //ViewBag.Departments = departmentService.GetAll();
                //return View(degree);
            }

            else
            {
                foreach (ValidationFailure _error in model.Errors)
                {
                    ModelState.AddModelError(_error.PropertyName, _error.ErrorMessage);
                }
            }
            ViewBag.Departments = departmentService.GetAll();
            return View(degree);
        }

        public ActionResult CourseDetails()
        {
            return View();
        }

        public ActionResult CourseDataLoad()
        {
            var data = courseService.GetAll().ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CourseUpdate(int? id)
        {
            Course course = courseService.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult CourseUpdate(Course course)
        {
            CourseValidation val = new CourseValidation();

            ValidationResult model = val.Validate(course);

            if (model.IsValid)

            {
                //if (!courseService.DuplicateCourse(course))
                //{
                    courseService.Update(course, course.CourseId);
                    ViewBag.Success = "Course Updated successfully";
                    return RedirectToAction("CourseDetails");
                //}
                //else
                //{
                //    ViewBag.success = "Course already existed.";
                //    return View(course);
                //}
            }

            else
            {
                foreach (ValidationFailure _error in model.Errors)
                {
                    ModelState.AddModelError(_error.PropertyName, _error.ErrorMessage);
                }
            }

            return View(course);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            ViewBag.departments = departmentService.GetAll();
            ViewBag.degrees = degreeService.GetAll();
            ViewBag.semesters = semesterService.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            StudentValidation val = new StudentValidation();

            ValidationResult model = val.Validate(student);

            if (model.IsValid)

            {
                if (!studentService.DuplicateStudent(student))
                {
                    studentService.Insert(student);
                    ViewBag.success = "Student added successfully";

                    StudentCredential sc = new StudentCredential();
                    sc.StudentId = student.StudentId;
                    sc.Password = "000";

                    credentialService.Insert(sc);

                    return RedirectToAction("Students");
                }
                else
                {
                    ViewBag.success = "Student already existed.";
                    ViewBag.departments = departmentService.GetAll();
                    ViewBag.degrees = degreeService.GetAll();
                    ViewBag.semesters = semesterService.GetAll();
                    return View();
                }
            }

            else

            {

                foreach (ValidationFailure _error in model.Errors)

                {

                    ModelState.AddModelError(_error.PropertyName, _error.ErrorMessage);

                }

            }

            ViewBag.departments = departmentService.GetAll();
            ViewBag.degrees = degreeService.GetAll();
            ViewBag.semesters = semesterService.GetAll();

            return View(student);
        }

        [HttpGet]
        public ActionResult UpdateStudent(string id)
        {
            Student s = studentService.GetBy_StudentID(id);
            ViewBag.departments = departmentService.GetAll();
            ViewBag.degrees = degreeService.GetAll();
            ViewBag.semesters = semesterService.GetAll();
            return View(s);

        }

        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            StudentValidation val = new StudentValidation();

            ValidationResult model = val.Validate(student);

            if (model.IsValid)

            {
                studentService.Update(student, student.Id);

                return RedirectToAction("Students");
            }
            else
            {
                foreach (ValidationFailure _error in model.Errors)
                {
                    ModelState.AddModelError(_error.PropertyName, _error.ErrorMessage);
                }
            }

            ViewBag.departments = departmentService.GetAll();
            ViewBag.degrees = degreeService.GetAll();
            ViewBag.semesters = semesterService.GetAll();

            return View(student);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(string StudentId)
        {
            Student student = studentService.GetBy_StudentID(StudentId);

            if (student != null)
            {
                return View("CourseRegistration");
            }
            else
            {

            }
            return View();
        }

        [HttpGet]
        public ActionResult CourseRegistration()
        {
            int id = Convert.ToInt32(TempData["studentID"]);
            List<Course> allCourses = new List<Course>();
            allCourses = courseService.GetAll().ToList();

            List<int> completedCourses = new List<int>();
            completedCourses = registrationService.GetALLCoursesByStudentId(TempData["studentID"].ToString()).Select(i => i.CourseId).ToList();

            List<Course> incompleteCourses = new List<Course>();
            for (int i = 0; i < allCourses.Count; i++)
            {
                if (!completedCourses.Contains(allCourses[i].CourseId))
                {
                    incompleteCourses.Add(allCourses[i]);
                }
            }
            return View(incompleteCourses);
        }

        [HttpPost]
        public ActionResult CourseRegistration(List<Course> registeredCourses)
        {
           for(int i=0;i<registeredCourses.Count;i++)
           {
                CourseRegistration registeredCourse = new CourseRegistration();
                registeredCourse.StudentId = TempData["studentID"].ToString();
                registeredCourse.SemesterId = currentSemID;
                registeredCourse.CourseId = registeredCourses[i].CourseId;
                registrationService.Insert(registeredCourse);
           }
           return View();
        }
    }
}