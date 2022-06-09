using MagazaSistem.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MagazaSistem.Controllers
{
    [AllowAnonymous]
    public class PasswordForgotController : Controller
    {
        // GET: PasswordForgot
        MagazaSistemContext db = new MagazaSistemContext();
        public ActionResult Index(Personnel personnel)
        {
           
                var personels = db.Personnel.FirstOrDefault(x => x.PersonelMail == personnel.PersonelMail);
            if (personels != null)
            {
                string email = personnel.PersonelMail;
                string sifre = personels.PersonelPassword;
                string name = personels.PersonelName;
                string surname = personels.PersonelSurname;
                Mail mails = new Mail();
                string mesaj = mails.Gonder(email, sifre, name, surname);
                ViewBag.Mesaj = mesaj;
            }
            else if (personnel.PersonelMail != null)
            {

                ViewBag.Mesaj = "Mail Adresiniz Kayıtlı Değil";

            }

            else { 
            
            
            }
              
                return View();
           
         
               
              
           
        }

        public class Mail
        {
            public string Gonder(string email,string sifre,string name,string surname)
            {
                try
                {


                        MailMessage mail = new MailMessage();
                        SmtpClient smtp = new SmtpClient();
                        smtp.Credentials = new NetworkCredential("miromagaza@gmail.com", "tttdbpfpzkktugrp");
                        smtp.Port = 587;
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                       

                        mail.IsBodyHtml = true;
                        mail.From = new MailAddress("miromagaza@gmail.com", "Şifre Yenileme İşlemi!");
                        mail.To.Add(email);
                        mail.IsBodyHtml = true;
                        mail.Subject ="Sisteme Kayıtlı Olan Şifreniz.";
                        mail.Body = "<b>Merhaha" + " "+name+" "+surname+" "+"şifreniz"+" </b>"+"<i>"+sifre+"</i>";
                        smtp.Send(mail);

                        return "Şifreniz kayıtlı olan e-mail adresinize gönderirdi!";

                    }

                catch
                {
                    return "Sistemsel bir hata oluştur lütfen daha sonra tekrar deneyin!";
                
                }
           


            }

        }
    }
}