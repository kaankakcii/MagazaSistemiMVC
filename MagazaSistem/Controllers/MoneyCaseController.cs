using MagazaSistem.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaSistem.Controllers
{
    public class MoneyCaseController : Controller
    {
        // GET: MoneyCase
        MagazaSistemContext db = new MagazaSistemContext();
        public ActionResult Index()
        {

            List<MoneyCase> moneyCases = db.MoneyCase.Where(x => x.MoneyCaseStatus==true).ToList();
            
            return View(moneyCases);
        }


        public ActionResult InvoiceListe(int id)
        {
            var kasa = db.MoneyCase.Find(id);
            Session["kasa"] = kasa.MoneyCaseName;
            List<Invoice> invoices = db.Invoice.Where(x => x.MoneyCaseId == id && x.AraToplam > 0).ToList();




            try
            {
                

                int ToplamKDV = Convert.ToInt32(((from t in db.Invoice where (t.MoneyCaseId == id) select t.Kdv).Sum()));
                ViewBag.KDV = ToplamKDV;

                int ToplamIndirim = Convert.ToInt32(((from t in db.Invoice where (t.MoneyCaseId == id) select t.Indirim).Sum()));
                ViewBag.ToplamIndirim = ToplamIndirim;

                int ToplamMiktar = Convert.ToInt32(((from t in db.Invoice where (t.MoneyCaseId == id) select t.Toplam).Sum()));
                ViewBag.ToplamMiktar = ToplamMiktar;

                int ToplamAdet = Convert.ToInt32(((from t in db.Invoice where (t.AraToplam != 0 && t.MoneyCaseId == id) select t).Count()));
                ViewBag.ToplamAdet = ToplamAdet;
            }
            catch
            {
                

            }

            return View(invoices);


        }

        [HttpGet]
        public ActionResult addMoneyCase() {


            return View();
        }

        [HttpPost]
        public ActionResult addMoneyCase(MoneyCase moneyCase)
        {
            moneyCase.MoneyCaseStatus = true;
            MoneyCase moneyCases = new MoneyCase();
            moneyCases.MoneyCaseStatus = moneyCase.MoneyCaseStatus;
            moneyCases.MoneyCaseName = moneyCase.MoneyCaseName;
            moneyCases.MoneyCaseAdres = moneyCase.MoneyCaseAdres;

            db.MoneyCase.Add(moneyCases);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}