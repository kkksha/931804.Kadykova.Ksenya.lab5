﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lab5.Models
{
    public class Hospitals
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Waiting for a name")][Display(Name = "Name")] public string name { get; set; }

        [Required(ErrorMessage = "Waiting for a address")][Display(Name = "Address")] public string adress { get; set; }

        [Required(ErrorMessage = "Waiting for a phone")][Display(Name = "Phones")][DataType(DataType.PhoneNumber)] public string phones { get; set; }
    }
}
