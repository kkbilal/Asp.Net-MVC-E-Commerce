using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ProductBrand { get; set; }
        public short ProductStock { get; set; }
        public decimal ProductCost { get; set; }
        public decimal ProductPrice { get; set; }
        public bool ProductStatus { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }
        public int CategoryId {  get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}