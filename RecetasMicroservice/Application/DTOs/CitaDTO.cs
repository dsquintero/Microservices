using System;

namespace RecetasMicroservice.Application.DTOs
{
    public class CitaDTO
    {
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