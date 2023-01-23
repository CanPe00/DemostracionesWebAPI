using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WSClinica.Data;
using WSClinica.Models;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private readonly DBClinicaCoreContext context;

        public ClinicaController(DBClinicaCoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Clinica>> Get()
        {
            return context.Clinicas.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Clinica> GetById(int id)
        {
            Clinica clinica = (from c in context.Clinicas
                               where c.ID== id
                               select c).SingleOrDefault();

            if (clinica == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Clinica clinica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Clinicas.Add(clinica);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Clinica clinica)
        {
            if (clinica.ID!= id)
            {
                return BadRequest();
            }
            context.Entry(clinica).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Clinica> Delete(int id)
        {
            Clinica clinica = (from c in context.Clinicas
                               where c.ID == id
                               select c).SingleOrDefault();

            if (clinica == null)
            {
                return NotFound();
            }
            context.Clinicas.Remove(clinica);
            context.SaveChanges();
            return Ok();
        }
    }
}
