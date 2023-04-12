using ShoppingCartAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShoppingCartAssignment.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {

                User user = context.Users.FirstOrDefault(emp => emp.UserName == model.UserName);

                if (user != null)
                {
                    if (user.UserPassword == model.UserPassword)
                    {
                        if (user.Role == "Admin")
                        {
                            FormsAuthentication.SetAuthCookie(model.UserName, false);
                            return RedirectToAction("Index", "Product");
                        }
                        else
                        {
                            FormsAuthentication.SetAuthCookie(model.UserName, false);
                            return RedirectToAction("Index", "Salesman");
                        }


                    }
                }
                else
                {
                    ModelState.AddModelError("", "invalid Username or Password");
                    
                }
                return View();

            }
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User model)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }

            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}



