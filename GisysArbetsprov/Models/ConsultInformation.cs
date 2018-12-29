using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GisysArbetsprov.Models
{
    public class ConsultInformation
    { 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Year of Employment")]
        public DateTime YearOfEmployment { get; set; }
        [Required]
        public int Hours { get; set; }
        public int Bonus { get; set; }
    }
}