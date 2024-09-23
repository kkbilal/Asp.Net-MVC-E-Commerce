using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{  [Authorize]
    public class EmployeeController : Controller
    {
        Context c = new Context();
        // GET: Employee
      
        public ActionResult Index()
        {
            var degerler = c.Employees.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewEmployee()
        {
            //Dropdownlistfor     
            List<SelectListItem> employeeList = (from x in c.Departmen.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.DepartmanName,
                                                    Value = x.DepartmanID.ToString()
                                                }).ToList();
            ViewBag.emply = employeeList;
            return View();
        }
        [HttpPost]
        public ActionResult NewEmployee(Employee employee)
        {
            c.Employees.Add(employee);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetEmployee(int id)
        {
            List<SelectListItem> employeeList = (from x in c.Departmen.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmanName,
                                                     Value = x.DepartmanID.ToString()
                                                 }).ToList();
            ViewBag.emply = employeeList;
            var employe = c.Employees.Find(id);
            return View("GetEmployee", employe);
        }
        public ActionResult UpdateEmployee(Employee k)
        {
            var empy = c.Employees.Find(k.EmployeeID);
            empy.EmployeeName = k.EmployeeName;
            empy.EmployeeSurname = k.EmployeeSurname;
            empy.EmployeeImage = k.EmployeeImage;
            empy.DepartmanID = k.DepartmanID;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}