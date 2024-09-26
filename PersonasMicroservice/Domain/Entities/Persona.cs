using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonasMicroservice.Domain.Entities
{
    public abstract class Persona
    {
        public Persona()
        {
            this.Active = true;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public int IdTipoPersona { get; set; } // 1 - Médico o 2 - Paciente
        public bool Active { get; set; }
        [ForeignKey("IdTipoPersona")]
        public virtual TipoPersona TipoPersona { get; set; }
    }
}