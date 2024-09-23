using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{[Authorize]
    public class CustomerController : Controller
    {
        Context c = new Context();
        // GET: Customer
        
        public ActionResult Index()
        {
            var degerler =c.Customers.Where(x=>x.CustomerStatus==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCustomer(Customer k)
        {
            k.CustomerStatus = true;
            c.Customers.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCustomer(int id)
        {
            var deger = c.Customers.Find(id);
            deger.CustomerStatus = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCustomer(int id)
        {
            var customer = c.Customers.Find(id);
            return View("GetCustomer", customer);
        }
        public ActionResult UpdateCustomer(Customer k)
        {
            var custom = c.Customers.Find(k.CustomerID);
            custom.CustomerName = k.CustomerName;
            custom.CustomerSurname = k.CustomerSurname;
            custom.CustomerCity = k.CustomerCity;
            custom.CustomerMail = k.CustomerMail;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CustomerSales(int id)
        {
            var CustSales = c.Sales.Where(x => x.CustomerID == id).ToList();
            var cr = c.Customers.Where(x=>x.CustomerID== id).Select(y=>y.CustomerName+" "+y.CustomerSurname).FirstOrDefault();
            ViewBag.cstmr = cr;
            return View(CustSales);
        }
    }
}