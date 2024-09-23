using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Customer k)
        {
            c.Customers.Add(k);
            c.SaveChanges();
            SendMail(k.CustomerMail, "Kayıt Onayı", $"Sayın {k.CustomerName}, kaydınız başarılı bir şekilde tamamlanmıştır.");
            return PartialView();
        }
        private void SendMail(string toEmail, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(toEmail);
            mail.From = new MailAddress("YourMail@outlook.com"); // Kendi e-posta adresinizi buraya yazın
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.office365.com"; // SMTP sunucu adresiniz
            smtp.Port = 587; // SMTP portu
            smtp.Credentials = new System.Net.NetworkCredential("YourMail@outlook.com", "YourPassword"); // Mail adresinizin kullanıcı adı ve şifresi
            smtp.EnableSsl = true; // Güvenli bağlantı kullanıyorsanız
            
            

            try
            {
                smtp.Send(mail);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("SMTP Hatası: " + ex.Message);
                Console.WriteLine("Detaylı Hata: " + ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message);
                Console.WriteLine("Detaylı Hata: " + ex.StackTrace);
            }
        }
        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(Customer p)
        {
            var bilgiler = c.Customers.FirstOrDefault(x => x.CustomerMail == p.CustomerMail && x.CustomerSifre == p.CustomerSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CustomerMail, false);
                Session["CustomerMail"] = bilgiler.CustomerMail.ToString();
                return RedirectToAction("Index","CustomerPanel");
            }
            else {
            return RedirectToAction("Index","Login"); 
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var admindeger = c.Admins.FirstOrDefault(x=>x.AdminName == admin.AdminName&&x.AdminPassword==admin.AdminPassword);
            if (admindeger != null)
            {
                FormsAuthentication.SetAuthCookie(admindeger.AdminName, false);
                Session["AdminName"] = admindeger.AdminName.ToString();
                return RedirectToAction("Index","Category");
            }
            return RedirectToAction("Index","Login");
        }
    }
}