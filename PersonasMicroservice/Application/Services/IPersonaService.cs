using PersonasMicroservice.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonasMicroservice.Application.Services
{
    public interface IPersonaService
    {
        Task<List<PersonaDTO>> GetAll();
        Task<PersonaDTO> GetById(int id);
        Task<PersonaDTO> GetByIdentificacion(int TipoPersona, string Identificacion);
        Task<string> Create(int idTipoPersona, PersonaDTO personaDto);
        Task<string> Update(int id, PersonaDTO personaDto);
        Task<string> Delete(int id);
    }
}