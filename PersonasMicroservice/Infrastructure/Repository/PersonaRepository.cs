using PersonasMicroservice.Domain.Entities;
using PersonasMicroservice.Infrastructure.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonasMicroservice.Infrastructure.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonasContext _context;

        public PersonaRepository(PersonasContext context)
        {
            _context = context;
        }
        public async Task<List<Persona>> GetAll()
        {
            var personas = _context.Personas.ToList();
            return personas;
        }

        public Task<Persona> GetById()
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Create(Persona persona)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Update(int Id, Persona persona)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Delete(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}