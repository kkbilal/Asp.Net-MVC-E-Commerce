using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;



namespace TicariOtomasyon.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category

        Context c = new Context();
        
        public ActionResult Index()
        {
            var degerler = c.Categories.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var ctgr = c.Categories.Find(id);
            c.Categories.Remove(ctgr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var category = c.Categories.Find(id);
            return View("GetCategory",category);
        }
        public ActionResult UpdateCategory(Category k)
        {
            var ctgr = c.Categories.Find(k.CategoryID);
            ctgr.CategoryName = k.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}