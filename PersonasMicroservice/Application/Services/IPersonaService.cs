using PersonasMicroservice.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonasMicroservice.Application.Services
{
    public interface IPersonaService
    {
        Task<List<PersonaDTO>> GetAll();
        Task<PersonaDTO> GetById();
        Task<string> Create(PersonaDTO personaDto);
        Task<string> Update(int Id, PersonaDTO personaDto);
        Task<string> Delete(int Id);
    }
}