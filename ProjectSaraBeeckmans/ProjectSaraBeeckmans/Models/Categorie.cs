﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSaraBeeckmans.Models
{
    public class Categorie
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Opmerking { get; set; }


    }
}
