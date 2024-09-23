using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{[Authorize]
    public class ProductController : Controller
    {
        Context c = new Context();
        // GET: Product
        
        public ActionResult Index()
        {
            var products = c.Products.Where(x => x.ProductStatus == true).ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            //Dropdownlistfor     
            List<SelectListItem> productList = (from x in c.Categories.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CategoryID.ToString()
                                                }).ToList();
            ViewBag.prdct = productList;
            return View();
        }
        [HttpPost]
        public ActionResult NewProduct(Product product)
        {
            c.Products.Add(product);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProduct(int id)
        {
            var deleteId = c.Products.Find(id);
            deleteId.ProductStatus = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetProduct(int id)
        {
            List<SelectListItem> productList = (from x in c.Categories.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CategoryID.ToString()
                                                }).ToList();
            ViewBag.prdct = productList;
            var product = c.Products.Find(id);
            return View("GetProduct", product);

        }
        public ActionResult UpdateProduct(Product k)
        {

            var upProduct = c.Products.Find(k.ProductID);
            upProduct.ProductName = k.ProductName;
            upProduct.CategoryId = k.CategoryId;
            upProduct.ProductBrand = k.ProductBrand;
            upProduct.ProductStatus = k.ProductStatus;
            upProduct.ProductCost = k.ProductCost;
            upProduct.ProductPrice = k.ProductPrice;
            upProduct.ProductImage = k.ProductImage;
            upProduct.ProductStock = k.ProductStock;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult NewSale(int id)
        {
            List<SelectListItem> employeeList = (from x in c.Employees.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                     Value = x.EmployeeID.ToString()
                                                 }).ToList();
            ViewBag.employeelist = employeeList;
            var prod = c.Products.Find(id);
            ViewBag.product2 = prod.ProductID;
            ViewBag.productprice = prod.ProductPrice;
            ViewBag.productstock = prod.ProductStock;
            return View();

        }
        
        [HttpPost]
        public ActionResult NewSale(Sale s)
        {
            s.SaleDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Sales.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index","Sale");
        }
    }
}