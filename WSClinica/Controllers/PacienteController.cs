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
    public class PacienteController : ControllerBase
    {
        private readonly DBClinicaCoreContext context;
        public PacienteController (DBClinicaCoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Paciente>> Get()
        {
            return context.Pacientes.ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<Paciente> GetById(int id)
        {
            Paciente paciente = (from p in context.Pacientes
                                where p.Id == id
                                select p).SingleOrDefault();
            if(paciente == null)
            {
                return NotFound();
            }
            return paciente;
        }

        [HttpPost]
        public ActionResult Post(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Pacientes.Add(paciente);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Paciente paciente)
        {
            if (paciente.Id != id)
            {
                return BadRequest();
            }
            context.Entry(paciente).State=EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Paciente> Delete(int id) {
            Paciente paciente = (from p in context.Pacientes
                                 where p.Id == id
                                 select p).SingleOrDefault();
            if (paciente == null)
            {
                return NotFound();
            }
            context.Pacientes.Remove(paciente);
            context.SaveChanges();
            return paciente;
        }
    }
}
