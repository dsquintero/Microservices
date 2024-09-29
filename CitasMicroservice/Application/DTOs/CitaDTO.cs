using System;

namespace CitasMicroservice.Api.DTOs
{
    public class CitaDTO
    {
        public string Paciente { get; set; }
        public string Medico { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }

    }
}