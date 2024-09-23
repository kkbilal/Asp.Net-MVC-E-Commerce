using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{
  [Authorize]
    public class StatisticsController : Controller
    {
        Context c = new Context();
        // GET: Statistics
      
        public ActionResult Index()
        {
            //total customer
            var customers = c.Customers.Count().ToString();
            ViewBag.TotalCount = customers;
            //total products
            var products = c.Products.Count().ToString();
            ViewBag.TotalProducts = products;
            //total employees
            var emp = c.Employees.Count().ToString();
            ViewBag.TotalEmployees = emp;
            //total categories
            var ctgr = c.Categories.Count().ToString();
            ViewBag.TotalCategories = ctgr;
            //total stock
            var stock = c.Products.Sum(x=>x.ProductStock).ToString();
            ViewBag.TotalStocks = stock;
            //total brands
            var brand = (from x in c.Products select x.ProductBrand).Distinct().Count().ToString();
            ViewBag.TotalBrands = brand;
            //most expensive
            var expensive = (from x in c.Products orderby x.ProductPrice descending select x.ProductName).FirstOrDefault();
            ViewBag.expensive= expensive;
            //best seller
            var best =c.Products.Where(u=>u.ProductID==( c.Sales.GroupBy(x=>x.ProductID).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.BestSeller = best;
            return View();
        }
        public ActionResult SimpleTables()
        {
            var sorgu = from x in c.Customers
                        group x by x.CustomerCity into g
                        select new ClassGroup
                        {
                            City = g.Key,
                            CustomerCount = g.Count(),
                        };
            return View(sorgu.ToList());
        }
        public PartialViewResult partial1()
        {
            var sorgu2 = from x in c.Employees
                         group x by x.Departman.DepartmanName into g
                         select new ClassGroup2
                         { 
                            
                             Departman = g.Key,
                             Count = g.Count(),
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult partial2()
        {
            var sorgu3 = c.Customers.ToList();

            return PartialView(sorgu3);
        }
    }
}