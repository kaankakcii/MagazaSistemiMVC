using MagazaSistem.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaSistem.Controllers
{
    
    public class ColorController : Controller
    {
        MagazaSistemContext db = new MagazaSistemContext();
        // GET: Color
        public ActionResult Index()
        {
            List<Color> colors = db.Color.Where(x => x.ColorStatus == true).ToList();
            return View(colors);
        }
        [HttpGet]
        public ActionResult Add() {


            return View();
        }


        [HttpPost]
        public ActionResult Add(Color color,string renk) {
            
            Color colors = new Color();
            colors.colorHex = renk;
            colors.ColorName = color.ColorName;
            color.ColorStatus = true;
            colors.ColorStatus = color.ColorStatus;
            
            db.Color.Add(color);
            db.SaveChanges();

            return RedirectToAction("Index");
        
        }













        [HttpGet]
        public ActionResult Update(int id)
        {
            Color colors = db.Color.Find(id);

            return View(colors);
        }


        [HttpPost]
        public ActionResult Update(Color color, string renk)
        {

            Color colors = db.Color.Find(color.ColorId);
            colors.colorHex = renk;
            colors.ColorName = color.ColorName;
            color.ColorStatus = true;
            colors.ColorStatus = color.ColorStatus;

            
            db.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {

            Color color = db.Color.Find(id);
            color.ColorStatus = false;
            db.SaveChanges();
            return RedirectToAction("index");
        }


    }
}