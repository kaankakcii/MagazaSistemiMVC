using MagazaSistem.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MagazaSistem.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login() {

            return View();
        }

        
        MagazaSistemContext db = new MagazaSistemContext();
        [HttpPost]
        public ActionResult Login(Personnel personnel) {

            var personels = db.Personnel.FirstOrDefault(x => x.PersonelMail == personnel.PersonelMail && x.PersonelPassword == personnel.PersonelPassword);

            if (personels != null)
            {
                
                FormsAuthentication.SetAuthCookie(personels.PersonelMail, false);
                Session["PersonelId"] = personels.PersonelId;
                Session["PersonelName"] = personels.PersonelName.ToString();
                Session["PersonelSurname"] = personels.PersonelSurname.ToString();
                Session["Yetki"] = personels.Authority.AuthorityName.ToString();








                Session["AuthorityName"] = personels.Authority.AuthorityName.ToString();
                Session["PersonelMail"] = personels.PersonelMail.ToString();

                Session["Date"] = DateTime.Now.Day.ToString();
                Session["Clock"] = DateTime.Now.Hour.ToString();           
                




                return RedirectToAction("Index", "Home");
            
            }

            else {

                ViewBag.Message = "E-mail veya şifre yanlış.";
                return View();
            }
            
        }



        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}