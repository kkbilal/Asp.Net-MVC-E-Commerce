using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Controllers
{[Authorize]
    public class DepartmanController : Controller
    {
        Context c = new Context();
        
        // GET: Departman
        public ActionResult Index()
        {
            var degerler = c.Departmen.Where(x => x.DepartmanStatus == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewDepartman()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewDepartman(Departman k)
        {
            c.Departmen.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteDepartman(int id)
        {
            var deger = c.Departmen.Find(id);
            deger.DepartmanStatus = false;
            c.SaveChanges();
            return RedirectToAction ("Index");
        }
        public ActionResult GetDepartman(int id)
        {
            var departman = c.Departmen.Find(id);
            return View("GetDepartman", departman);
        }
        public ActionResult UpdateDepartman(Departman k)
        {
            var ctgr = c.Departmen.Find(k.DepartmanID);
            ctgr.DepartmanName = k.DepartmanName;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DetailsDepartman(int id)
        {   
            var degerler1 = c.Employees.Where(x => x.DepartmanID == id).ToList();
            var dpt = c.Departmen.Where(x=>x.DepartmanID==id).Select(y=>y.DepartmanName).FirstOrDefault();
            ViewBag.dpt1 = dpt;
            return View(degerler1);
            
        }
        public ActionResult DepEmployeeSales(int id)
        {   
            var sales = c.Sales.Where(x=>x.EmployeeID == id).ToList();
            var Emp = c.Employees.Where(x=>x.EmployeeID == id).Select(y=>y.EmployeeName+" "+y.EmployeeSurname).FirstOrDefault();
            ViewBag.dEmp= Emp;
            return View(sales);
        }
    }
}