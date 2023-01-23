using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WSClinica.Data;
using WSClinica.Models;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly DBClinicaCoreContext context;

        public MedicoController(DBClinicaCoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Medico>> Get()
        {
            return context.Medicos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Medico> GetById(int id)
        {
            Medico medico= (from m in context.Medicos
                           where m.IdMedico == id
                           select m).SingleOrDefault();

            if(medico == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Medicos.Add(medico);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody]Medico medico) {
            if (medico.IdMedico != id)
            {
                return BadRequest();
            }
            context.Entry(medico).State= EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Medico> Delete(int id) {
            Medico medico = (from m in context.Medicos
                             where m.IdMedico == id
                             select m).SingleOrDefault();

            if (medico == null)
            {
                return NotFound();
            }
            context.Medicos.Remove(medico);
            context.SaveChanges();
            return Ok();
        }
    }
}
