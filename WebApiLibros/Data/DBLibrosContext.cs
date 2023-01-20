using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WebApiLibros.Models;

namespace WebApiLibros.Data
{
    public class DBLibrosContext:DbContext
    {
        public DBLibrosContext(DbContextOptions<DBLibrosContext> options):base(options) { }

        public DbSet<Autor> autores { get; set; }
        public DbSet<Libro> libros { get; set; }
    }
}
