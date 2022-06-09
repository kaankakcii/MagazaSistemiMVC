using MagazaSistem.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaSistem.Controllers
{
    public class ReportController : Controller
    {
        MagazaSistemContext db = new MagazaSistemContext();
        // GET: Report
        public ActionResult Index()
        {
            return View();
            
        }



        public ActionResult invoiceList()
        {

            List<Invoice> ınvoices = db.Invoice.Where(x => x.Toplam != 0).ToList();

            int ToplamKDV = Convert.ToInt32(((from t in db.Invoice select t.Kdv).Sum()));
            ViewBag.KDV = ToplamKDV;

            int ToplamIndirim = Convert.ToInt32(((from t in db.Invoice select t.Indirim).Sum()));
            ViewBag.ToplamIndirim = ToplamIndirim;

            int ToplamMiktar = Convert.ToInt32(((from t in db.Invoice select t.Toplam).Sum()));
            ViewBag.ToplamMiktar = ToplamMiktar;

            int ToplamAdet = Convert.ToInt32(((from t in db.Invoice where t.AraToplam !=0 select t ).Count()));
            ViewBag.ToplamAdet = ToplamAdet;

            return View(ınvoices);
        }

        [HttpGet]
        public ActionResult FaturaDetay(int id) {

            List<InvoiceAndProduct> ınvoicesAndPoducts = db.InvoiceAndProduct.Where(x => x.Invoice.InvoiceId == id).ToList();
            
            Invoice ınvoice = db.Invoice.Find(id);
            Session["FaturaTarihi"] = ınvoice.DüzenlenmeTarihi;
            

            ViewBag.Sorumlu = ınvoice.Sorumlu;
            ViewBag.FaturaNo = ınvoice.InvoiceNo;

            int ToplamAdet = Convert.ToInt32(((from t in db.InvoiceAndProduct where t.InvoiceId == id select t).Count()));
            ViewBag.ToplamAdet = ToplamAdet;

            int AraToplam = Convert.ToInt32(((from t in db.Invoice where t.InvoiceId==id select t.AraToplam).Sum()));
            ViewBag.AraToplam = AraToplam;

            int Toplam = Convert.ToInt32(((from t in db.Invoice where t.InvoiceId == id select t.Toplam).Sum()));
            ViewBag.Toplam =Toplam;

            int kdv = Convert.ToInt32(((from t in db.Invoice where t.InvoiceId == id select t.Kdv).Sum()));
            ViewBag.KDV = kdv;

            int indirim = Convert.ToInt32(((from t in db.Invoice where t.InvoiceId == id select t.Indirim).Sum()));
            ViewBag.ind = indirim;

            return View(ınvoicesAndPoducts);
        }


        [HttpGet]
        public ActionResult StokList()
        {

            List<Product> products = db.Product.Where(x =>x.ProductStatus==true).ToList();

            int ToplamAdet = Convert.ToInt32(((from t in db.Product where t.ProductStatus==true select t.ProductStockAmount).Sum()));
            ViewBag.ToplamAdet = ToplamAdet;
            
            int toplamDeger=0;
            int toplamDeger2=0;
           

            for (int i = 0; i < products.Count; i++) {

                toplamDeger = products[i].ProductStockAmount * products[i].ProductPurchasePrice;
                

                toplamDeger2 = toplamDeger2+toplamDeger;

            }

            ViewBag.ToplamDeger = toplamDeger2;

            return View(products);
        }

    }
}