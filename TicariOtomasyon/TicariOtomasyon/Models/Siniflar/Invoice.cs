using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerialno { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceOrderno { get; set; }
        public DateTime InvoiceDate { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string InvoiceTax { get; set; }
        public DateTime InvoiceTime { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string InvoiceRecipient {  get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string InvoiceDeliverer { get; set;}
        public ICollection<InvoiceItem> InvoiceItems { get; set; } 
    }
}