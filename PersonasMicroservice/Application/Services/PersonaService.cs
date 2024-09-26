using PersonasMicroservice.Api.DTOs;
using PersonasMicroservice.Domain.Entities;
using PersonasMicroservice.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonasMicroservice.Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;

        public PersonaService(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        public async Task<List<Persona>> GetAll()
        {
            return await _personaRepository.GetAll();
        }

        public async Task<PersonaDTO> GetById(int id)
        {
            var persona = await _personaRepository.GetById(id);
            if (persona == null) return null;

            // Mapeo de Persona a PersonaDTO
            var personaDto = new PersonaDTO
            {
                Nombre = persona.Nombre,
                TipoPersona = persona.TipoPersona?.Desc
            };

            return personaDto;
        }


        public async Task<string> Create(PersonaDTO personaDto)
        {
            // Mapeo de PersonaDTO a Persona
            var persona = new Persona
            {
                Nombre = personaDto.Nombre,
                FechaDeNacimiento = personaDto.FechaDeNacimiento,
                IdTipoPersona = personaDto.IdTipoPersona
            };

            return await _personaRepository.Create(persona);
        }

        public async Task<string> Update(int id, PersonaDTO personaDto)
        {
            // Mapeo de PersonaDTO a Persona
            var persona = new Persona
            {
                Nombre = personaDto.Nombre,
                FechaDeNacimiento = personaDto.FechaDeNacimiento,
                IdTipoPersona = personaDto.IdTipoPersona,
                Active = personaDto.Active
            };

            return await _personaRepository.Update(id, persona);
        }

        public async Task<string> Delete(int id)
        {
            return await _personaRepository.Delete(id);
        }
    }
}