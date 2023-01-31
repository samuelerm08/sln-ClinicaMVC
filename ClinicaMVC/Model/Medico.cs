using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaMVC.Models
{
    [Table("Medico")]
    public class Medico
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        [RegularExpression(@"^[A-Z]{2}[0-9]{4}$")]
        public string Matricula { get; set; }
    }
}
