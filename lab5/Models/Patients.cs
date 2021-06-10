using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
    public class Patients
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Waiting for a name")] [Display(Name = "Name")] public string name { get; set; }
        [Required(ErrorMessage = "Waiting for a disease")] [Display(Name = "Disease")]  public string disease { get; set; }
    }
}
