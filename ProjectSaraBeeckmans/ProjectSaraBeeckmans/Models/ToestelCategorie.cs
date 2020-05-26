using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSaraBeeckmans.Models
{
    public class ToestelCategorie
    {
        public int ToestelId { get; set; }
        public Toestel toestel { get; set; }
        public int CategorieId { get; set; }
        public Categorie categorie { get; set; }
    }
}
