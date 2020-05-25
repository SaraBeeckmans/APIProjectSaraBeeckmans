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
        public List<Bedrijf> GetBedrijfs(string naam, string email)
        {
            //return hardwareInventaris.Bedrijven.ToList();

            IQueryable<Bedrijf> query = hardwareInventaris.Bedrijven;

            if (!string.IsNullOrWhiteSpace(naam))
                query = query.Where(d => d.BedrijfNaam == naam);
            if (!string.IsNullOrWhiteSpace(email))
                query = query.Where(d => d.Email == email);

            return query.ToList();
          
        }

        //FIND
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetBedrijf (int id)
        {
            //var bedrijf = hardwareInventaris.Bedrijven.Include(d => d.Toestellen).SingleOrDefault(d => d.id == id);
            var bedrijf = hardwareInventaris.Bedrijven.Include(d => d.Toestellen).SingleOrDefault(d => d.id == id);

            if (bedrijf == null)
                return NotFound();

            return Ok(bedrijf);
        }


        //INSERT
        [HttpPost]
        public IActionResult CreateBedrijf([FromBody] Bedrijf newBedrijf)
        {
            hardwareInventaris.Bedrijven.Add(newBedrijf);
            hardwareInventaris.SaveChanges();
            //Stuur een result 201 met het boek als content
            return Created("", newBedrijf);

        }


       

        //DELETE
        [Route("{id}")]
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
