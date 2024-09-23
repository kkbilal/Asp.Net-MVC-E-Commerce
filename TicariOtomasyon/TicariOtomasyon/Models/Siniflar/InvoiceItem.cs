using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class InvoiceItem
    {
        [Key]
        public int ItemID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string ItemDescription { get; set; }
        public int ItemCount { get; set; }
        public decimal ItemCost { get; set; }
        public decimal ItemPrice { get; set; }
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

    }
}