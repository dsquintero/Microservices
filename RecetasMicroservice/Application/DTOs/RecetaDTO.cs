using System;
using System.Collections.Generic;

namespace RecetasMicroservice.Application.DTOs
{
    public class RecetaDTO
    {
        public int IdCita { get; set; }
        public string Paciente { get; set; }
        public string Medico { get; set; }
        public DateTime Fecha_Emision { get; set; }
        public string Desc { get; set; }
        public ICollection<MedicamentoDTO> Medicamentos { get; set; } = new List<MedicamentoDTO>();
    }
}