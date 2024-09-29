using AutoMapper;
using PersonasMicroservice.Domain.Entities;
using PersonasMicroservice.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonasMicroservice.Application.DTOs;

namespace PersonasMicroservice.Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public PersonaService(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        public async Task<List<PersonaDTO>> GetAll()
        {
            var personas = await _personaRepository.GetAll();
            return _mapper.Map<List<PersonaDTO>>(personas);
        }

        public async Task<PersonaDTO> GetById(int id)
        {
            var persona = await _personaRepository.GetById(id);
            if (persona == null) return null;
            return _mapper.Map<PersonaDTO>(persona);
        }

        public async Task<Persona> GetByIdentificacion(int TipoPersona, string Identificacion)
        {
            var persona = await _personaRepository.GetByIdentificacion(TipoPersona, Identificacion.Trim());
            if (persona == null) return null;
            return persona;
        }

        public async Task<string> Create(int idTipoPersona, PersonaDTO personaDto)
        {
            var persona = _mapper.Map<Persona>(personaDto);
            persona.IdTipoPersona = idTipoPersona;
            return await _personaRepository.Create(persona);
        }

        public async Task<string> Update(int id, PersonaDTO personaDto)
        {
            var persona = _mapper.Map<Persona>(personaDto);
            return await _personaRepository.Update(id, persona);
        }

        public async Task<string> Delete(int id)
        {
            return await _personaRepository.Delete(id);
        }
    }
}