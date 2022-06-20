using MagazaSistem.Entites.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaSistem.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        MagazaSistemContext db = new MagazaSistemContext();
        public ActionResult Index()
        {
            List<Brand> brands = db.Brand.Where(x => x.BrandStatus == true).ToList();

            return View(brands);
        
        }

        [HttpGet]
        public ActionResult Add() {

            return View();
        
        }

        [HttpPost]
        public ActionResult Add(Brand brand) {
            brand.BrandStatus = true;
            Brand brands = new Brand();
            brands.BrandName = brand.BrandName;
            brands.BrandStatus = brand.BrandStatus;

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);

                string yol = "~/Image/" + dosyaadi;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                brand.BrandImgUrl = "/Image/" + dosyaadi;

            }

            db.Brand.Add(brand);
            db.SaveChanges();

            return RedirectToAction("Index");
        }







        public ActionResult Update(int id)
        {
            Brand brands = db.Brand.Find(id);

            return View(brands);

        }

        [HttpPost]
        public ActionResult Update(Brand brand)
        {
            brand.BrandStatus = true;
            Brand brands = db.Brand.Find(brand.BrandId);
            brands.BrandName = brand.BrandName;
            brands.BrandStatus = brand.BrandStatus;

            try
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Image/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    brands.BrandImgUrl = "/Image/" + dosyaadi + uzanti;

                }
            }

            catch { }
            db.SaveChanges();

            return RedirectToAction("Index");
        }















        public ActionResult Delete(int id)
        {

            Brand brands = db.Brand.Find(id);
            brands.BrandStatus = false;
            db.SaveChanges();
            return RedirectToAction("index");
        }



    }
}