using ShoppingCartAssignment.Models;
using ShoppingCartAssignment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartAssignment.Controllers
{
    [Authorize(Roles ="User")]
    public class SalesmanController : Controller
    {
        // GET: Salesman
        ApplicationDbContext db = new ApplicationDbContext();


        private IGenericRepository<Product> repository = null;
        public SalesmanController()
        {
            this.repository = new GenericRepository<Product>();
        }
        public SalesmanController(IGenericRepository<Product> repository)
        {
            this.repository = repository;
        }
        [HttpGet]

        [Authorize(Roles ="Admin,User")]
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }
    }
}