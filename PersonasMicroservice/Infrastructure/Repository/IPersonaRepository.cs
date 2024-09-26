using PersonasMicroservice.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonasMicroservice.Infrastructure.Repository
{
    public interface IPersonaRepository
    {
        Task<List<Persona>> GetAll();
        Task<Persona> GetById();
        Task<string> Create(Persona personaDto);
        Task<string> Update(int Id, Persona personaDto);
        Task<string> Delete(int Id);
    }
}