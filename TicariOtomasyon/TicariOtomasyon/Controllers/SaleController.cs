using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{  [Authorize]
    public class SaleController : Controller
    {
        Context c = new Context();
        // GET: Sale
      
        public ActionResult Index()
        {
            var degerler = c.Sales.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewSale()
        {
            List<SelectListItem> productList = (from x in c.Products.Where(x=>x.ProductStatus==true).ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.ProductName,
                                                     Value = x.ProductID.ToString()
                                                 }).ToList();
            ViewBag.productlist = productList;
            List<SelectListItem> customerList = (from x in c.Customers.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.CustomerName+" "+x.CustomerSurname,
                                                    Value = x.CustomerID.ToString()
                                                }).ToList();
            ViewBag.customerlist = customerList;
            List<SelectListItem> employeeList = (from x in c.Employees.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.EmployeeName+" "+x.EmployeeSurname,
                                                    Value = x.EmployeeID.ToString()
                                                }).ToList();
            ViewBag.employeelist = employeeList;
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(Sale s) 
        {
            s.SaleDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Sales.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult GetSale(int id)
        {
            List<SelectListItem> productList = (from x in c.Products.Where(x => x.ProductStatus == true).ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.ProductName,
                                                    Value = x.ProductID.ToString()
                                                }).ToList();
            ViewBag.productlist = productList;
            List<SelectListItem> customerList = (from x in c.Customers.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CustomerName + " " + x.CustomerSurname,
                                                     Value = x.CustomerID.ToString()
                                                 }).ToList();
            ViewBag.customerlist = customerList;
            List<SelectListItem> employeeList = (from x in c.Employees.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                     Value = x.EmployeeID.ToString()
                                                 }).ToList();
            ViewBag.employeelist = employeeList;

            var salee = c.Sales.Find(id);
            return View("GetSale", salee);

        }
      
        public ActionResult UpdateSale(Sale k)
        {

            var upSale = c.Sales.Find(k.SaleID);
            upSale.ProductID = k.ProductID;
            upSale.EmployeeID = k.EmployeeID;
            upSale.CustomerID = k.CustomerID;
            upSale.SaleCost = k.SaleCost;
            upSale.SalePrice = k.SalePrice;
            upSale.SaleNumber = k.SaleNumber;
            upSale.SaleDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DetailsSale(int id)
        {
            var degerler = c.Sales.Where(x=>x.SaleID == id).ToList();
            return View(degerler);
        }

    }
}