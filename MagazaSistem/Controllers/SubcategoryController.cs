using MagazaSistem.Entites.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaSistem.Controllers
{
    public class SubcategoryController : Controller
    {
        MagazaSistemContext db = new MagazaSistemContext();
        // GET: Subcategory
        public ActionResult Index()
        {

            List<Subcategory> subcategories = db.Subcategory.Where(x => x.SubcategoryStatus == true).ToList();

            return View(subcategories);
            

        }

        [HttpGet]
        public ActionResult Add()
        {

            List<SelectListItem> category = db.Category.AsNoTracking().Where(x => x.CategoryStatus == true)
                .Select(s => new SelectListItem
                {
                    Value = s.CategoryId.ToString(),
                    Text = s.CategoryName

                }).ToList();
            ViewBag.Categories = category;
            return View();

        }

        [HttpPost]
        public ActionResult Add(Subcategory subcategory)
        {
            subcategory.SubcategoryStatus = true;
            Subcategory subcategorys = new Subcategory();
            subcategorys.SubcategoryStatus = subcategory.SubcategoryStatus;
            subcategorys.SubcategoryName = subcategory.SubcategoryName;
            subcategorys.Category= db.Category.Find(subcategory.CategoryId);


            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);

                string yol = "~/Image/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                subcategory.ImageUrl = "/Image/" + dosyaadi;

            }



            db.Subcategory.Add(subcategory);
            db.SaveChanges();

            return RedirectToAction("Index");
        }







        public ActionResult Update(int id)
        {
            Subcategory subcategorys = db.Subcategory.Find(id);
            List<SelectListItem> category = db.Category.AsNoTracking().Where(x => x.CategoryStatus == true)
                .Select(s => new SelectListItem
                {
                    Value = s.CategoryId.ToString(),
                    Text = s.CategoryName

                }).ToList();
            ViewBag.Categories = category;
            return View(subcategorys);

        }

        [HttpPost]
        public ActionResult Update(Subcategory subcategory)
        {
            subcategory.SubcategoryStatus = true;
            Subcategory subcategorys = db.Subcategory.Find(subcategory.SubcategoryId);
            subcategorys.SubcategoryStatus = subcategory.SubcategoryStatus;
            subcategorys.SubcategoryName = subcategory.SubcategoryName;
            subcategorys.Category = db.Category.Find(subcategory.CategoryId);

            try
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);

                    string yol = "~/Image/" + dosyaadi;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    subcategory.ImageUrl = "/Image/" + dosyaadi;

                }
            }
            catch { }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            Subcategory subcategorys = db.Subcategory.Find(id);
            subcategorys.SubcategoryStatus = false;
            db.SaveChanges();
            return RedirectToAction("index");
        }


    }
}
