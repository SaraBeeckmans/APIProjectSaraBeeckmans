﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProjectSaraBeeckmans.Data;
using ProjectSaraBeeckmans.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectSaraBeeckmans.Controllers
{
    [Route("/api/v1/supplier/")]
    public class SupplierController : Controller
    {
        private readonly HardwareInventaris hardwareInventaris = new HardwareInventaris();

        //SELECT SQL

        [Route("list")]
        [HttpGet]
        public List<Supplier> GetSupplies(string naam, string email)
        {
            //return hardwareInventaris.Bedrijven.ToList();

            IQueryable<Supplier> query = hardwareInventaris.Suppliers;

            if (!string.IsNullOrWhiteSpace(naam))
                query = query.Where(d => d.Name == naam);
            if (!string.IsNullOrWhiteSpace(email))
                query = query.Where(d => d.Email == email);

            return query.ToList();

        }

        //FIND
        [Route("find/{str}")]
        [HttpGet]
        public IActionResult GetSupplier(string str)
        { var supplier = hardwareInventaris.Suppliers.Where(n => n.Name.Contains(str) || n.Email.Contains(str) || n.Adres.Contains(str) || n.Tel.Contains(str));

            if (supplier == null)
                return NotFound();

            return Ok(supplier);
        }


        //INSERT
        [HttpPost]
        public IActionResult CreateSupplier([FromBody] Supplier newSupplier)
        {
            hardwareInventaris.Suppliers.Add(newSupplier);
            hardwareInventaris.SaveChanges();
            //Stuur een result 201 met het boek als content
            return Created("", newSupplier);

        }




        //DELETE
        [Route("delete/{id}")]
        [HttpDelete]

        public IActionResult DeleteSupplier(int id)
        {
            var sup = hardwareInventaris.Suppliers.Find(id);
            if (sup == null)
            {
                return NotFound();
            }
            hardwareInventaris.Suppliers.Remove(sup);
            hardwareInventaris.SaveChanges();

            return NoContent();
        }

        //UPDATE
        public IActionResult UpdateSupplier([FromBody] Supplier updateSupplier)
        {
            var orgSupplier = hardwareInventaris.Suppliers.Find(updateSupplier.id);
            if (orgSupplier == null)
                return NotFound();

            orgSupplier.Name = updateSupplier.Name;
            orgSupplier.Adres = updateSupplier.Adres;
            orgSupplier.Email = updateSupplier.Email;
            orgSupplier.Tel = updateSupplier.Tel;

            hardwareInventaris.SaveChanges();
            return Ok(orgSupplier);
        }



    }
}
