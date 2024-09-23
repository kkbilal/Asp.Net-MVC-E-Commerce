using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        public DateTime SaleDate { get; set; }
        public int SaleNumber { get; set; }
        public decimal SalePrice { get; set; } 
        public decimal SaleCost { get; set; }
        public int ProductID { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual Customer Customer { get; set; }

    }
}