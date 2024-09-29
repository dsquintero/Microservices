using PersonasMicroservice.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonasMicroservice.Infrastructure.Repository
{
    public interface IPersonaRepository
    {
        Task<List<Persona>> GetAll();
        Task<Persona> GetById(int id);
        Task<Persona> GetByIdentificacion(int TipoPersona, string Identificacion);
        Task<string> Create(Persona persona);
        Task<string> Update(int id, Persona persona);
        Task<string> Delete(int id);
    }
}