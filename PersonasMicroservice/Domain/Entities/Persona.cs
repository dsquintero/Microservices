using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonasMicroservice.Domain.Entities
{
    public class Persona
    {
        public Persona()
        {
            this.Activo = true;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Range(1, 2, ErrorMessage = "El IdTipoPersona solo puede ser 1 (Médico) o 2 (Paciente).")]
        public int IdTipoPersona { get; set; } // 1 - Médico o 2 - Paciente
        [Index(IsUnique = true)]
        [StringLength(20)]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fecha_Nacimiento { get; set; }
        [RegularExpression("^[FM]$", ErrorMessage = "El género debe ser 'F' o 'M'.")]
        [StringLength(1)]
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("IdTipoPersona")]
        public virtual TipoPersona TipoPersona { get; set; }
    }
}