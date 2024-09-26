using PersonasMicroservice.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonasMicroservice.Infrastructure.Repository
{
    public interface IPersonaRepository
    {
        Task<List<PersonaDTO>> GetAll();
        Task<PersonaDTO> GetById();
        Task<string> Create(PersonaDTO personaDto);
        Task<string> Update(int Id, PersonaDTO personaDto);
        Task<string> Delete(int Id);
    }
}