using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GisysArbetsprov.Models
{
    public class ConsultInformation
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime YearsOfEmployment { get; set; }
        public int Hours { get; set; }
        public int Bonus { get; set; }
    }
}