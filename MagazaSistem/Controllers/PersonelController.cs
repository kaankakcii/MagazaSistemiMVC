using MagazaSistem.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagazaSistem.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        MagazaSistemContext db = new MagazaSistemContext();
        // GET: Product
        
        public ActionResult Index()
        {
            List<Personnel> personels= db.Personnel.Where(x => x.PersonelStatus == true).ToList();

            return View(personels);
        }



        public ActionResult Delete(int id)
        {

            Personnel personnels = db.Personnel.Find(id);
            personnels.PersonelStatus = false;
            db.SaveChanges();
            return RedirectToAction("index");
        }


        [HttpGet]
        public ActionResult Add()
        {
            /*Kategori*/
            List<SelectListItem> authority = db.Authority.AsNoTracking().Where(x => x.AuthorityStatus == true)
                .Select(s => new SelectListItem
                {
                    Value = s.AuthorityId.ToString(),
                    Text = s.AuthorityName

                }).ToList();

            ViewBag.Authorities = authority;
            return View();

        }

        [HttpPost]
        public ActionResult Add(Personnel personnel)
        {

     
         


            personnel.PersonelStatus = true;
            Personnel personnels = new Personnel();
            personnels.PersonelStatus = personnel.PersonelStatus;
            personnels.PersonelName = personnel.PersonelName;
            personnels.PersonelSurname = personnel.PersonelSurname;
            personnels.PersonelTelephone = personnel.PersonelTelephone;

            char[] cr = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {

                result += cr[r.Next(0, cr.Length - 1)].ToString();

            }
            personnel.PersonelPassword = result;
            personnels.PersonelPassword = personnel.PersonelPassword;
            personnels.PersonelMail = personnel.PersonelMail;
            personnels.PersonelAddress = personnel.PersonelAddress;
            personnels.PersonelEmploymentDate = personnel.PersonelEmploymentDate;
            personnels.PersonelAge = personnel.PersonelAge;
            personnels.Authority = db.Authority.Find(personnel.AuthorityId);
            personnels.PersonelStatus = personnel.PersonelStatus;
            personnels.PersonelWage = personnel.PersonelWage;

           

            db.Personnel.Add(personnel);
            db.SaveChanges();

            return RedirectToAction("Index");
        }




        [HttpGet]
        public ActionResult Update(int id)
        {
            Personnel personnels = db.Personnel.Find(id);
            /*Kategori*/
            List<SelectListItem> authority = db.Authority.AsNoTracking().Where(x => x.AuthorityStatus == true)
                .Select(s => new SelectListItem
                {
                    Value = s.AuthorityId.ToString(),
                    Text = s.AuthorityName

                }).ToList();

            ViewBag.Authorities = authority;
            return View(personnels);

        }

        [HttpPost]
        public ActionResult Update(Personnel personnel)
        {
            Personnel personnels = db.Personnel.Find(personnel.PersonelId);
            personnel.PersonelStatus = true;

            personnels.PersonelStatus = personnel.PersonelStatus;
            personnels.PersonelName = personnel.PersonelName;
            personnels.PersonelSurname = personnel.PersonelSurname;
            personnels.PersonelTelephone = personnel.PersonelTelephone;
            personnels.PersonelPassword = personnel.PersonelPassword;
            personnels.PersonelMail = personnel.PersonelMail;
            personnels.PersonelAddress = personnel.PersonelAddress;
            personnels.PersonelEmploymentDate = personnel.PersonelEmploymentDate;
            personnels.PersonelAge = personnel.PersonelAge;
            personnels.Authority = db.Authority.Find(personnel.AuthorityId);
            
            personnels.PersonelWage = personnel.PersonelWage;


 


            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }





}
