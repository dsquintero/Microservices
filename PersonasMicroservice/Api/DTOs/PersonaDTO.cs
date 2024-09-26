using System;

namespace PersonasMicroservice.Api.DTOs
{
    public class PersonaDTO
    {
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string TipoPersona { get; set; }

    }
}