using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Notification
    {
        public int NotificationID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; } // Admin tarafından okunup okunmadığı
        public bool IsApproved { get; set; } // Sipariş onaylandı mı/red mi
    }
}