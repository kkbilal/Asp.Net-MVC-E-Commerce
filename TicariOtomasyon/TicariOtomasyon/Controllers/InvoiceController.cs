using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{[Authorize]
    public class InvoiceController : Controller
    {
        Context c = new Context();
        // GET: Invoice
        
        public ActionResult Index()
        {
            var degerler = c.Invoices.ToList();
            return View(degerler);
        }
    }
}