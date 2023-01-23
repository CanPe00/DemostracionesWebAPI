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
    public class HabitacionController : ControllerBase
    {
        private readonly DBClinicaCoreContext context;

        public HabitacionController(DBClinicaCoreContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Habitacion>> Get()
        {
            return context.Habitaciones.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Habitacion> GetById(int id)
        {
            Habitacion habitacion = (from h in context.Habitaciones
                                     where h.Id == id
                                     select h).SingleOrDefault();

            if (habitacion == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost]
        public ActionResult Post(Habitacion habitacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Habitaciones.Add(habitacion);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Habitacion habitacion)
        {
            if (habitacion.Id != id)
            {
                return BadRequest();
            }
            context.Entry(habitacion).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Habitacion> Delete(int id)
        {
            Habitacion habitacion = (from h in context.Habitaciones
                                     where h.Id == id
                                     select h).SingleOrDefault();

            if (habitacion == null)
            {
                return NotFound();
            }
            context.Habitaciones.Remove(habitacion);
            context.SaveChanges();
            return Ok();
        }
    }
}
