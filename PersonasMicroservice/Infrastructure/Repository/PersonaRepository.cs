using PersonasMicroservice.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonasMicroservice.Infrastructure.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        public Task<List<PersonaDTO>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<PersonaDTO> GetById()
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Create(PersonaDTO personaDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Update(int Id, PersonaDTO personaDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Delete(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}