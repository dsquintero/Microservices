using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RecetasMicroservice.Api.DTOs;
using RecetasMicroservice.Domain.Entities;
using RecetasMicroservice.Infrastructure.Repository;

namespace RecetasMicroservice.Application.Services
{
    public class RecetaService : IRecetaService
    {
        private readonly IRecetaRepository _personaRepository;
        private readonly IMapper _mapper;

        public RecetaService(IRecetaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        public async Task<List<RecetaDTO>> GetAll()
        {
            var personas = await _personaRepository.GetAll();
            return _mapper.Map<List<RecetaDTO>>(personas);
        }

        public async Task<RecetaDTO> GetById(int id)
        {
            var persona = await _personaRepository.GetById(id);
            if (persona == null) return null;
            return _mapper.Map<RecetaDTO>(persona);
        }

        public async Task<string> Create(int idTipoPersona, RecetaDTO personaDto)
        {
            var persona = _mapper.Map<Receta>(personaDto);
            persona.IdTipoPersona = idTipoPersona;
            return await _personaRepository.Create(persona);
        }

        public async Task<string> Update(int id, RecetaDTO personaDto)
        {
            var persona = _mapper.Map<Receta>(personaDto);
            return await _personaRepository.Update(id, persona);
        }

        public async Task<string> Delete(int id)
        {
            return await _personaRepository.Delete(id);
        }
    }
}