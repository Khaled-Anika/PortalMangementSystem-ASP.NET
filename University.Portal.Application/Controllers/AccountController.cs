using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using University.Portal.Entites.AdminEntites;
using University.Portal.Entites.StudentEntites;
using University.Portal.Entites.VModel.Entites;
using University.Portal.Infrastructure;

namespace University.Portal.Application.Controllers
{

    public class AccountController : Controller
    {
        private readonly DbContext _Context;

        //Use Autofac
        public AccountController(DbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(VLogin login, string ReturnUrl = "")
        {
            string message = "";
            if (ModelState.IsValid)
            {

                var userid = login.UserId;
                string[] id = userid.Split('-');
                string check = id[0];
                int count = 0;

                if (id.Length == 3)
                {

                    for (int i = 0; i < check.Length; i++)
                    {
                        count = count + 1;
                    }



                    if (count == 3)
                    {
                        try
                        {
                            var student = _Context.Set<StudentCredential>().Where(x => x.StudentId == login.UserId && x.Password == login.Password).FirstOrDefault();

                            if (student != null)
                            {
                                int timeout = login.RememberMe ? 2 : 3;
                                var ticket = new FormsAuthenticationTicket(login.UserId, login.RememberMe, timeout);
                                string encrypted = FormsAuthentication.Encrypt(ticket);
                                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                                cookie.Expires = DateTime.Now.AddMinutes(timeout);
                                cookie.HttpOnly = true;
                                Response.Cookies.Add(cookie);


                                //Return URL
                                if (Url.IsLocalUrl(ReturnUrl))
                                {
                                    return Redirect(ReturnUrl);
                                }

                                //After Successfully Login
                                else
                                {
                                    Session["UserId"] = student.StudentId;
                                    return RedirectToAction("Index", "Student");
                                    //  Response.Write("<script>alert('Welcome to User')</script>");
                                }



                            }

                            else
                            {
                                message = "Invalid UserID Or Password";
                            }


                        }

                        catch (Exception ex)
                        {
                            message = ex.Message;

                        }

                    }

                    else if (count == 4)
                    {
                        try
                        {
                            var Admin = _Context.Set<AdminCredential>().Where(x => x.AdminId == login.UserId && x.Password == login.Password).FirstOrDefault();

                            if (Admin != null)
                            {
                                int timeout = login.RememberMe ? 2 : 3;
                                var ticket = new FormsAuthenticationTicket(login.UserId, login.RememberMe, timeout);
                                string encrypted = FormsAuthentication.Encrypt(ticket);
                                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                                cookie.Expires = DateTime.Now.AddMinutes(timeout);
                                cookie.HttpOnly = true;
                                Response.Cookies.Add(cookie);


                                //Return URL
                                if (Url.IsLocalUrl(ReturnUrl))
                                {
                                    return Redirect(ReturnUrl);
                                }

                                //After Successfully Login
                                else
                                {
                                    Session["UserId"] = Admin.AdminId;
                                    return RedirectToAction("Students", "Admin");
                                    //  Response.Write("<script>alert('Welcome to User')</script>");
                                }



                            }

                            else
                            {
                                message = "Invalid UserID Or Password";
                            }


                        }

                        catch (Exception ex)
                        {
                            message = ex.Message;

                        }

                    }

                    else
                    {
                        message = "Input Correct Format Your Userid";

                    }




                }

                else
                {
                    message = "Input Correct Format Your Userid";

                }



            }

            ViewBag.Message = message;
            return View(login);

        }


        [Authorize]
        public ActionResult Logout()
        {

            Session.Clear();
            FormsAuthentication.SignOut();
            //FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("Index", "Account");

        }



    }
}