using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSaraBeeckmans.Models
{
    public class Toestel
    {
        //public Toestel()
        //{
        //    this.Categories = new HashSet<Categorie>();
        //}

        [Key]
        public int id { get; set; }
        [Required]
        public string SerieNummer { get; set; }
        public string AankoopDatum { get; set; }
        public string Garantie { get; set; }
        public double Prijs { get; set; }

        public int? BedrijfId { get; set; }
        public int? SupplierId { get; set; }


        public Bedrijf Bedrijf { get; set; }
        public Supplier Supplier { get; set; }


        public virtual IList<ToestelCategorie> ToestelCategories { get; set; }
    }
}
