using PersonasMicroservice.Api.DTOs;
using PersonasMicroservice.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonasMicroservice.Application.Services
{
    public interface IPersonaService
    {
        Task<List<Persona>> GetAll();
        Task<PersonaDTO> GetById();
        Task<string> Create(PersonaDTO personaDto);
        Task<string> Update(int Id, PersonaDTO personaDto);
        Task<string> Delete(int Id);
    }
}