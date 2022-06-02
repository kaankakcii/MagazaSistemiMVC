using MagazaSistem.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaSistem.Controllers
{
    
    public class PosController : Controller
    {
        MagazaSistemContext db = new MagazaSistemContext();
        // GET: Pos
        public ActionResult Index()
        {
            ProductAndInvoiceProduct pıp = new ProductAndInvoiceProduct();
            pıp.Products = db.Product.Where(x=>x.ProductStatus==true).ToList();
                      
            ViewBag.fat = Session["faturaNo"];
            
            float faturaNo = Convert.ToInt32(Session["faturaNo"]);


            pıp.InvoiceAndProducts = db.InvoiceAndProduct.Where(x=>x.Invoice.InvoiceNo==faturaNo).ToList();
           
            Session["fiyat2"] = Convert.ToInt32(Session["fiyat2"]) + Convert.ToInt32(Session["fiyat"]);

            ViewBag.Kdv = Convert.ToInt32(Session["fiyat2"]) * 18 / 100;

            ViewBag.Toplam = (Convert.ToInt32(Session["fiyat2"]) * 18 / 100) + Convert.ToInt32(Session["fiyat2"]);
            
            
            
            
           return View(pıp);
        }


        [HttpPost]
        public ActionResult urunEkle() {

            return View();

        }

        [HttpGet]
        public ActionResult urunEkle(int id){

            
            Product products = db.Product.Find(id); 
            InvoiceAndProduct ınvoiceAndProducts = new InvoiceAndProduct();
            
            int fautraId = Convert.ToInt32(Session["faturaId"]);
            Invoice ınvoices = db.Invoice.Find(fautraId);

            ınvoiceAndProducts.ProductId = products.ProductId;
            ınvoiceAndProducts.ToplamFiyat = products.ProductPrice;
            ınvoiceAndProducts.InvoiceId =ınvoices.InvoiceId;

            db.InvoiceAndProduct.Add(ınvoiceAndProducts);
            db.SaveChanges();

            Session["fiyat"]= products.ProductPrice;

            return RedirectToAction("Index");


        }


        public ActionResult faturaEkle() {

            Random r = new Random();
            int faturaNo = r.Next(1, 15001);
            Session["faturaNo"] = faturaNo;

            Invoice ınvoices = new Invoice();
            ınvoices.InvoiceNo = faturaNo;
            ınvoices.AraToplam = Convert.ToInt32(Session["fiyat2"]);
            ınvoices.Toplam = (ınvoices.AraToplam * 18 / 100)+ınvoices.AraToplam;
            ınvoices.Kdv = ınvoices.AraToplam * 18 / 100;
            ınvoices.Sorumlu = Convert.ToString(Session["PersonelName"]);
            ınvoices.DüzenlenmeTarihi = DateTime.Now;
            ınvoices.MoneyCaseId = 1;

            db.Invoice.Add(ınvoices);
            db.SaveChanges();
            Session["faturaId"] = ınvoices.InvoiceId;
            ViewBag.fatu = Session["faturaId"];



            Session["fiyat"] = 0;
            Session["fiyat2"] = 0;

            return RedirectToAction("Index");
        }


        public ActionResult delete(int id) {

            
            InvoiceAndProduct ınvoiceAndProduct = db.InvoiceAndProduct.Find(id);
            Session["fiyat2"] = Convert.ToInt32(Session["fiyat2"]) - ınvoiceAndProduct.Product.ProductPrice;
            Session["fiyat"] = 0;
            db.InvoiceAndProduct.Remove(ınvoiceAndProduct);
            db.SaveChanges();
            

            return RedirectToAction("index");
        }


    }
}