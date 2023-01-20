using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        //INYECCION DE DEPENENCIA --INICIA
        //Propiedad 
        private readonly DBLibrosContext context;
        //Constructor del controlador
        public AutorController(DBLibrosContext context)
        {
            this.context = context;
        }
        //INYECCION DE DEPENENCIA --FIN

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.autores.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Autor> GetById(int id)
        {
            Autor autor = (from a in context.autores
                           where a.IdAutor == id
                          select a).SingleOrDefault();
            return autor;
            
            //return context.autores.Find(id);
        }

        [HttpPost]
        public ActionResult Post(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.autores.Add(autor);
            context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            Autor autor = (from a in context.autores
                           where a.IdAutor == id
                           select a).SingleOrDefault();
            if (autor==null)
            {
                return NotFound();
            }
            context.autores.Remove(autor);
            context.SaveChanges();
            return autor;
        }

        //UPDATE
        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody]Autor autor)
        {
            if (id!=autor.IdAutor)
            {
                return BadRequest();
            }

            context.Entry(autor).State=EntityState.Modified;

            //Autor autorOriginal = context.autores.Find(id);
            //autorOriginal.IdAutor = autor.IdAutor;
            //autorOriginal.Edad = autor.Edad;
            //autorOriginal.Nombre= autor.Nombre;
            //autorOriginal.Apellido= autor.Apellido;
            context.SaveChanges();
            return Ok();
        }


    }
}
