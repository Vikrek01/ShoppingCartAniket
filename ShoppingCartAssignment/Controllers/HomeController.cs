using ShoppingCartAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}


/*
context.Users.Add(new User { UserName = "Aman", UserPassword = "123", Role = "Admin" });
context.Users.Add(new User { UserName = "Aniket", UserPassword = "abc", Role = "User" });



context.Products.Add(new Product { PId = Guid.NewGuid(), PName = "Aman Badalia", PDescription = "Title", PPrice = "500", PImage = "~/Content/Images/client-6.png" });


context.SaveChanges();
base.Seed(context);*/