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
    public class EspecialidadController : ControllerBase
    {
        private readonly DBClinicaCoreContext context;

        public EspecialidadController(DBClinicaCoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Especialidad>> Get()
        {
            return context.Especialidades.ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<Especialidad> GetById(int id)
        {
            Especialidad especialidad = (from e in context.Especialidades
                                         where e.Id == id
                                         select e).SingleOrDefault();
            if (especialidad == null)
            {
                return NotFound();
            }
            return especialidad;
        }

        [HttpPost]
        public ActionResult Post(Especialidad especialidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Especialidades.Add(especialidad);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Especialidad especialidad)
        {
            if (especialidad.Id != id)
            {
                return BadRequest();
            }
            context.Entry(especialidad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Especialidad> Delete(int id)
        {
            Especialidad especialidad = (from e in context.Especialidades
                                         where e.Id == id
                                         select e).SingleOrDefault();
            if (especialidad == null)
            {
                return NotFound();
            }
            context.Especialidades.Remove(especialidad);
            context.SaveChanges();
            return especialidad;
        }
    }
}
