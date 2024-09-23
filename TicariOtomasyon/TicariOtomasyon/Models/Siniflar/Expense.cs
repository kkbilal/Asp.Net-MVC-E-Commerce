    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Expense
    {
        [Key]
        public int ExpenseID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string ExpenseDescription { get; set; }
        public DateTime ExpenseDate { get; set; }
        
        public decimal ExpenseCost { get; set;}
    }
}