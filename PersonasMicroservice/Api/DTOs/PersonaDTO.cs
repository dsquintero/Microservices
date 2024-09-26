using System;

namespace PersonasMicroservice.Api.DTOs
{
    public class PersonaDTO
    {
        public string Nombre { get; set; }
        public int TipoPersona { get; set; }
        public string Especialidad { get; set; } // Solo para médicos
        public string NumeroLicencia { get; set; } // Solo para médicos
        public DateTime FechaNacimiento { get; set; } // Solo para pacientes
        public string NumeroHistoriaClinica { get; set; } // Solo para pacientes
    }
}