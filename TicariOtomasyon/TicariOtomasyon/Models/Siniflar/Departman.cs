using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int DepartmanID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string DepartmanName { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public bool DepartmanStatus { get; set; }
    }
}