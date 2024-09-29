using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMicroservice.Domain.Entities
{
    public class Cita
    {
        public Cita()
        {
            this.Estado = "Pendiente";
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }

    }
}