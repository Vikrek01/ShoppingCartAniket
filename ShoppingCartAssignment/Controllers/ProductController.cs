using ShoppingCartAssignment.Models;
using ShoppingCartAssignment.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartAssignment.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ProductController : Controller
    {
        // GET: Product //
        ApplicationDbContext db = new ApplicationDbContext();


        private IGenericRepository<Product> repository = null;
        public ProductController()
        {
            this.repository = new GenericRepository<Product>();
        }
        public ProductController(IGenericRepository<Product> repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(HttpPostedFileBase file,Product product)
        {
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssfff") + filename;
            string extension = Path.GetExtension(file.FileName);


            string path = Path.Combine(Server.MapPath("~/Content/Images/"), _filename);
            product.PImage = "~/Content/Images/" + _filename;

            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
            {
                if (file.ContentLength < 10000)
                {
                    
                    repository.Insert(product);
                    file.SaveAs(path);
                    ViewBag.msg = "Student Added";
                    ModelState.Clear();
                    repository.Save();
                    return RedirectToAction("Index");
                    
                }
                else
                {
                    ViewBag.msg = "File Size should be Less than 1 Mb";
                }
            }
            else
            {
                ViewBag.msg = "Invalid File Type";
            }
           
              return View();
        }
        [HttpGet]
        public ActionResult EditEmployee(Guid id)
        {
            Product model = repository.GetById(id);
          
            Session["ImgPath"] = model.PImage;
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEmployee(HttpPostedFileBase file, Product product)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                    string extension = Path.GetExtension(file.FileName);


                    string path = Path.Combine(Server.MapPath("~/Content/Images/"), _filename);
                    product.PImage = "~/Content/Images/" + _filename;

                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        if (file.ContentLength < 10000)
                        {
                           // db.Entry(product).State = EntityState.Modified;
                            string OldImgPath = Request.MapPath(Session["ImgPath"].ToString());
                               repository.Update(product);
                               repository.Save();
                
                                file.SaveAs(path);
                                if (System.IO.File.Exists(OldImgPath))
                                {
                                    System.IO.File.Delete(OldImgPath);
                                }
                                ViewBag.msg = "Student Added";
                                TempData["msg"] = "Data Updated";
                                return RedirectToAction("Index");
                            
                        }
                        else
                        {
                            ViewBag.msg = "File Size should be Less than 1 Mb";
                        }
                    }
                    else
                    {
                        ViewBag.msg = "Invalid File Type";
                    }
                }
            }
            else
            {
                product.PImage = Session["ImgPath"].ToString();
                db.Entry(product).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    TempData["msg"] = "Data Updated";
                    return RedirectToAction("Index");
                }
            }

            return View();
        }



        [HttpGet]
        public ActionResult DeleteEmployee(Guid id)
        {
            Product model = repository.GetById(id);
            return View(model);
        }

        [HttpGet,ActionName("Delete")]
        public ActionResult Delete(Guid id)
        {
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid id)
        {
            Product model= repository.GetById(id);
            return View(model);
        }


    }
}