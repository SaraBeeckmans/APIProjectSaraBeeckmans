using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProjectSaraBeeckmans.Data;
using ProjectSaraBeeckmans.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectSaraBeeckmans.Controllers
{
    [Route ("/api/v1/bedrijf/")]
    public class BedrijfController:Controller
    {
        private readonly HardwareInventaris hardwareInventaris = new HardwareInventaris();

        //SELECT SQL
        [Route("list")]
        [HttpGet]
        public IActionResult GetBedrijfs()
        {

            var bedrijven = hardwareInventaris.Bedrijven;
            return Ok(bedrijven);


        }



        //FIND
        [Route("find/{str}")]
        [HttpGet]
        public IActionResult GetBedrijf (string str)
        {
            //var bedrijf = hardwareInventaris.Bedrijven.Include(d => d.Toestellen).SingleOrDefault(d => d.id == id);
            var bedrijf = hardwareInventaris.Bedrijven.Where(n => n.BedrijfNaam.Contains(str) || n.Email.Contains(str) || n.Adres.Contains(str) || n.Tel.Contains(str));

            if (bedrijf == null)
                return NotFound();

            return Ok(bedrijf);
        }


        //INSERT
        [Route("add")]
        [HttpPut]
        public IActionResult CreateBedrijf([FromQuery] string bedrijfsNaam, [FromQuery] string email, [FromQuery] string adres, [FromQuery] string tel)
        {
            Bedrijf bedrijf = new Bedrijf();
            bedrijf.BedrijfNaam = bedrijfsNaam;
            bedrijf.Adres = adres;
            bedrijf.Email = email;
            bedrijf.Tel = tel;
            hardwareInventaris.Bedrijven.Add(bedrijf);
            hardwareInventaris.SaveChanges();
            //Stuur een result 201 met het boek als content
            return Created("", bedrijf);

        }


       

        //DELETE
        [Route("delete/{id}")]
        [HttpDelete]

        public IActionResult DeleteBedrijf(int id)
        {
            var bedrijf = hardwareInventaris.Bedrijven.Find(id);
            if(bedrijf == null)
            {
                return NotFound();
            }
            hardwareInventaris.Bedrijven.Remove(bedrijf);
            hardwareInventaris.SaveChanges();

            return NoContent();
        }

        //UPDATE
        public IActionResult UpdateBedrijf([FromBody] Bedrijf updateBedrijf)
        {
            var orgBedrijf = hardwareInventaris.Bedrijven.Find(updateBedrijf.id);
            if (orgBedrijf == null)
                return NotFound();

            orgBedrijf.BedrijfNaam = updateBedrijf.BedrijfNaam;
            orgBedrijf.Adres = updateBedrijf.Adres;
            orgBedrijf.Email = updateBedrijf.Email;
            orgBedrijf.Tel = updateBedrijf.Tel;

            hardwareInventaris.SaveChanges();
            return Ok(orgBedrijf);
        }



    }
}
