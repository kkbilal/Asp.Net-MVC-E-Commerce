using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string EmployeeName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string EmployeeSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string EmployeeImage { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public int DepartmanID {  get; set; }
        public virtual Departman Departman { get; set; }

    }
}