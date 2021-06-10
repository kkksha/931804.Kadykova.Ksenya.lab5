using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
    public class Doctors
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Waiting for a name")][Display(Name = "Name")] public string name { get; set; }
        [Required(ErrorMessage = "Waiting for a speciality")][Display(Name = "Speciality")] public string speciality { get; set; }
    }
}
