using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
//        GET—> traer todos los libros
//GET—>traer todos los libros por autorId
//GET→ Traer uno por Id
//POST→Insertar libros, retornar un Ok()
//PUT→modificar libro, pasado id y modelo.retornar un NoContent()
//DELETE —>Eliminar libro.Retornar el libro eliminado

        private readonly DBLibrosContext context;

        public LibroController( DBLibrosContext context )
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.libros.ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<Libro> GetById(int id)
        {
            Libro libro= (from l in context.libros
                         where l.IdLibro == id
                         select l).SingleOrDefault();

            if (libro == null)
            {
                return NotFound();
            }
            return libro;
        }

        [HttpGet("listado/{idAutor}")]
        public ActionResult<IEnumerable<Libro>> GetByAutorId(int idAutor)
        {
            List<Libro> libros = (from l in context.libros
                                  where l.IdAutor== idAutor
                                select l).ToList();
            return libros;

        }

        [HttpPost]
        public ActionResult Post(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.libros.Add(libro);
            context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Libro libro)
        {
            if (id != libro.IdLibro)
            {
                return BadRequest();
            }

            context.Entry(libro).State = EntityState.Modified;
            context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Libro libro = (from l in context.libros
                           where l.IdLibro == id
                           select l).SingleOrDefault();

            if (libro == null)
            {
                return NotFound();
            }
            context.libros.Remove(libro);
            context.SaveChanges();
            return Ok();
        }
    }
}
