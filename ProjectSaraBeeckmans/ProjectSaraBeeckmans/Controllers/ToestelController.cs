using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProjectSaraBeeckmans.Data;
using ProjectSaraBeeckmans.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ProjectSaraBeeckmans.Controllers
{
    [Route("/api/v1/toestel/")]
    public class ToestelController : Controller
    {
        private readonly HardwareInventaris hardwareInventaris = new HardwareInventaris();

        //SELECT SQL
        [Route("list")]
        [HttpGet]
        public IActionResult GetToestellen()
        {

           

            var toestellen = hardwareInventaris.Toesellen.Include(d => d.Bedrijf).Include(s => s.Supplier);
            return Ok(toestellen);



        }


        //FIND
        [Route("find/{str}")]
        [HttpGet]
        public IActionResult GetToestel(string str)
        {
            //Relatie suppliers nog toevoegen
            //var bedrijf = hardwareInventaris.Bedrijven.Include(d => d.Toestellen).SingleOrDefault(d => d.id == id);
            var toestel = hardwareInventaris.Toesellen.Where(n => n.SerieNummer.Contains(str)  || n.AankoopDatum.Contains(str) || n.Garantie.Contains(str));


            if (toestel == null)
                return NotFound();

            return Ok(toestel);
        }


        //INSERT
        [HttpPost]
        public IActionResult CreateToestel([FromBody] Toestel newToestel)
        {
            hardwareInventaris.Toesellen.Add(newToestel);
            hardwareInventaris.SaveChanges();
            //Stuur een result 201 met het boek als content
            return Created("", newToestel);

        }




        //DELETE
        [Route("delete/{id}")]
        [HttpDelete]

        public IActionResult DeleteToestel(int id)
        {
            var toestel = hardwareInventaris.Toesellen.Find(id);
            if (toestel == null)
            {
                return NotFound();
            }
            hardwareInventaris.Toesellen.Remove(toestel);
            hardwareInventaris.SaveChanges();

            return NoContent();
        }

        //UPDATE
        public IActionResult UpdateToestel([FromBody] Toestel updateToestel)
        {
            var orgToestel = hardwareInventaris.Toesellen.Find(updateToestel.id);
            if (orgToestel == null)
                return NotFound();

            orgToestel.SerieNummer = updateToestel.SerieNummer;
            orgToestel.AankoopDatum = updateToestel.AankoopDatum;
            orgToestel.Prijs = updateToestel.Prijs;
            orgToestel.Garantie = updateToestel.Garantie;

            hardwareInventaris.SaveChanges();
            return Ok(orgToestel);
        }



    }
}
