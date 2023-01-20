using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibros.Models
{
    [Table("Libro")]
    public class Libro
    {
        [Key]
        public int IdLibro { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Titulo { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Descripcion { get; set; }
        public Autor Autor { get; set; }

        [ForeignKey(nameof(Autor))]
        public int IdAutor { get; set; }
    }
}
