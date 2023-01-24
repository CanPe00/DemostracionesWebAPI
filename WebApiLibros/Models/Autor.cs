using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiLibros.Validations;

namespace WebApiLibros.Models
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage ="El Nombre es campo obligatorio")]
        [PrimeraLetraMayAtributte]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "El Apellido es campo obligatorio")]
        [PrimeraLetraMayAtributte]
        public string Apellido { get; set; }

        [Range(18, 110, ErrorMessage = "Debe ser > a 18 y < a 110")]
        public int? Edad { get; set; }

        [FechaNacAtributte]
        public DateTime FechaDeNacimiento { get; set; }

        public List<Libro> Libros { get; set; }

    }
}
