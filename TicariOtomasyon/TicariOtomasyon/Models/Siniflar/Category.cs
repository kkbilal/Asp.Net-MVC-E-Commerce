using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}