using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{[Authorize]
    public class CustomerPanelController : Controller
    {
        Context c = new Context();
        
        // GET: CustomerPanel
        public ActionResult Index()
        {
            var mail = (string)Session["CustomerMail"];
            var degerler = c.Customers.FirstOrDefault(x=>x.CustomerMail == mail);   
            ViewBag.mail = mail;
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(Customer k) 
        {
            var deger = c.Customers.Find(k.CustomerID);

            return RedirectToAction("Index");
        }
        public ActionResult Orders()
        {
            var mail = (string)Session["CustomerMail"];
            var id = c.Customers.Where(x=>x.CustomerMail==mail.ToString()).Select(y=>y.CustomerID).FirstOrDefault();
            var deger = c.Sales.Where(x => x.CustomerID == id).ToList();
            return View(deger);    
        }
        public ActionResult ProductList()
        {
            var products = c.Products.Where(p => p.ProductStatus == true).ToList();
            return View(products);
        }
        [HttpPost]
        public ActionResult AddToCart(int productId)
        {
            var product = c.Products.Find(productId);

            // Sepet boşsa yeni bir sepet oluştur
            if (Session["Cart"] == null)
            {
                List<Product> cart = new List<Product>();
                cart.Add(product);
                Session["Cart"] = cart;
            }
            else
            {
                // Sepet doluysa mevcut sepeti al
                List<Product> cart = (List<Product>)Session["Cart"];
                cart.Add(product);
                Session["Cart"] = cart;
            }

            // Sepeti Session'dan tekrar al ve toplam fiyatı hesapla
            List<Product> currentCart = (List<Product>)Session["Cart"];
            decimal totalPrice = currentCart.Sum(item => item.ProductPrice);
            Session["TotalPrice"] = totalPrice;

            return RedirectToAction("Cart");
        }
        public ActionResult Cart()
        {
            var cart = (List<Product>)Session["Cart"];
            if (cart == null)
            {
                cart = new List<Product>();
            }
            ViewBag.TotalPrice = cart.Sum(item => item.ProductPrice);
            return View(cart);
        }

        // Sepeti boşaltma
        [HttpPost]
        public ActionResult ClearCart()
        {
            Session["Cart"] = null;
            Session["TotalPrice"] = 0;
            return RedirectToAction("Cart");
        }

        // Sepet güncelleme
        [HttpPost]
        public ActionResult UpdateCart(Dictionary<int, int> quantities)
        {
            var cart = (List<Product>)Session["Cart"];
            if (cart == null)
            {
                cart = new List<Product>();
            }

            // Sepeti güncelle
            foreach (var productId in quantities.Keys)
            {
                var product = c.Products.Find(productId);
                if (product != null)
                {
                    var existingProduct = cart.FirstOrDefault(p => p.ProductID == productId);
                    if (existingProduct != null)
                    {
                        for (int i = 0; i < quantities[productId] - 1; i++) // Existing quantity is already counted, so subtract 1
                        {
                            cart.Add(product);
                        }
                    }
                }
            }

            Session["Cart"] = cart;
            ViewBag.TotalPrice = cart.Sum(item => item.ProductPrice);
            return RedirectToAction("Cart");
        }
        [HttpGet]
        public ActionResult Payment()
        {
            // Sepet toplam tutarını ViewBag'e koyuyoruz, ki ödeme sayfasında gösterelim
            var totalPrice = Session["TotalPrice"] != null ? (decimal)Session["TotalPrice"] : 0;
            ViewBag.TotalPrice = totalPrice;

            return View();
        }
        [HttpPost]
        public ActionResult Payment(string CardNumber, string CardName, string ExpiryDate, string CVV)
        {
            var cart = (List<Product>)Session["Cart"];
            decimal totalPrice = (decimal)Session["TotalPrice"];

            // Ödeme işlemini tamamla
            bool paymentSuccess = SimulatePayment(CardNumber, CardName, ExpiryDate, CVV, totalPrice);

            if (paymentSuccess)
            {
                // Sipariş ile ilgili bildirim oluştur
                var mail = (string)Session["CustomerMail"];
                var customer = c.Customers.FirstOrDefault(x => x.CustomerMail == mail);

                Notification notification = new Notification
                {
                    Title = "Yeni Sipariş",
                    Description = $"Müşteri {customer.CustomerName} yeni bir sipariş verdi. Toplam Tutar: {totalPrice}",
                    CreatedAt = DateTime.Now,
                    IsRead = false,
                    IsApproved = false
                };

                c.Notification.Add(notification);
                c.SaveChanges();

                // Sepeti boşalt
                Session["Cart"] = null;
                Session["TotalPrice"] = 0;

                return RedirectToAction("PaymentConfirmation");
            }
            else
            {
                ViewBag.PaymentError = "Ödeme başarısız. Lütfen bilgilerinizi kontrol edin.";
                return View();
            }
        }

        private bool SimulatePayment(string cardNumber, string cardName, string expiryDate, string cvv, decimal amount)
        {
            // Burada ödeme işlemini simüle ediyoruz.
            // Gerçek ödeme sistemleri bu aşamada entegrasyon gerektirir.

            if (!string.IsNullOrEmpty(cardNumber) && !string.IsNullOrEmpty(cardName) && !string.IsNullOrEmpty(expiryDate) && !string.IsNullOrEmpty(cvv))
            {
                // Ödeme başarılı kabul ediliyor
                return true;
            }

            return false;
        }
        public ActionResult PaymentConfirmation()
        {
            return View();
        }
    }


}