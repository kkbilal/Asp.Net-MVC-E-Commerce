using System.Linq;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    [Authorize] // Sadece adminlere izin veriyoruz
    public class NotificationsController : Controller
    {
        Context c = new Context();

        // Bildirimleri listele
        public ActionResult Index()
        {
            var notifications = c.Notification.Where(x => x.IsRead == false).ToList();
            return View(notifications);
        }

        // Bildirimi onayla
        public ActionResult Approve(int id)
        {
            var notification = c.Notification.Find(id);
            if (notification != null)
            {
                notification.IsApproved = true;
                notification.IsRead = true; // Onaylandığında okundu olarak işaretle
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Bildirimi reddet
        public ActionResult Reject(int id)
        {
            var notification = c.Notification.Find(id);
            if (notification != null)
            {
                notification.IsApproved = false;
                notification.IsRead = true; // Reddedildiğinde okundu olarak işaretle
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
