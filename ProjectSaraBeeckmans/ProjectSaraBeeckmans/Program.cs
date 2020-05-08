using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ProjectSaraBeeckmans.Data;
using ProjectSaraBeeckmans.Models;

namespace ProjectSaraBeeckmans
{
    public class Program
    {
        public static void Main(string[] args)
        {
             HardwareInventaris hardwareInventaris = new HardwareInventaris();

            Bedrijf bedrijfRelationsComp = new Bedrijf()
            {
                BedrijfNaam = "Relations Comp",
                Email = "relationscomp@gmail.com",
                Adres = "Bredabaan 222 Merksem",
                Tel = "045896323"


            };
            hardwareInventaris.Bedrijven.Add(bedrijfRelationsComp);

            Toestel laptop = new Toestel()
            {
                SerieNummer = "5NGTFD566",
                AankoopDatum = "10/2/2020",
                Garantie = "2 jaar",
                Prijs = 1500



            };
            hardwareInventaris.Toesellen.Add(laptop);

            hardwareInventaris.SaveChanges();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
