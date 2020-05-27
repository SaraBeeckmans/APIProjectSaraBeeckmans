using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSaraBeeckmans.Models
{
    public class Bedrijf
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string BedrijfNaam { get; set; }
        [Required]
        public string Email { get; set; }
        public string Adres { get; set; }
        public string Tel { get; set; }
        [JsonIgnore]
        public virtual IList<Toestel> Toestellen { get; set; }
    }
}
