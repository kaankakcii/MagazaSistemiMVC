using MagazaSistem.Entites.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaSistem.Controllers
{
    public class CategoryController : Controller
    {
        MagazaSistemContext db = new MagazaSistemContext();
        // GET: Category
        
        public ActionResult Index()
        {
            List<Category> categories = db.Category.Where(x => x.CategoryStatus == true).ToList();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Add()
        {
            
            return View();

        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            category.CategoryStatus = true;
            Category categorys = new Category();
            categorys.CategoryStatus = category.CategoryStatus;
            categorys.CategoryName = category.CategoryName;


            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);

                string yol = "~/Image/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                category.ImageUrl = "/Image/" + dosyaadi;

            }



            db.Category.Add(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        public ActionResult Delete(int id)
        {

            Category categorys = db.Category.Find(id);
            categorys.CategoryStatus = false;
            db.SaveChanges();
            return RedirectToAction("index");
        }


    }
}