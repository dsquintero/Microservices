using PersonasMicroservice.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonasMicroservice.Application.DTOs;

namespace PersonasMicroservice.Application.Services
{
    public interface IPersonaService
    {
        Task<List<PersonaDTO>> GetAll();
        Task<PersonaDTO> GetById(int id);
        Task<Persona> GetByIdentificacion(int TipoPersona, string Identificacion);
        Task<string> Create(int idTipoPersona, PersonaDTO personaDto);
        Task<string> Update(int id, PersonaDTO personaDto);
        Task<string> Delete(int id);
    }
}