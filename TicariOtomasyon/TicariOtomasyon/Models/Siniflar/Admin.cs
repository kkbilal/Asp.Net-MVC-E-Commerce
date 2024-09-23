using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string AdminName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string AdminPassword { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        public string AdminStatus { get; set; }
    }
}