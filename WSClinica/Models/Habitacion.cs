using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    [Table("Habitacion")]
    public class Habitacion
    {
        [Key]
        public int Id { get; set; }

        //[Range(1, 100, ErrorMessage = "Solo se permite números entre 1 y 100")]
        [RegularExpression("(A{3}[0-9]{3})*")]
        public int Numero { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Estado { get; set; }
        [ForeignKey(nameof(Clinica))]
        public int ClinicaID { get; set;}
        public Clinica Clinica { get; set; }
    }
}
