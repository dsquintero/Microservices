using AutoMapper;
using CitasMicroservice.Api.DTOs;
using CitasMicroservice.Domain.Entities;
using CitasMicroservice.Infrastructure.Repository;
using System.Threading.Tasks;

namespace CitasMicroservice.Application.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public CitaService(ICitaRepository citaRepository, IMapper mapper)
        {
            _citaRepository = citaRepository;
            _mapper = mapper;
        }

        public async Task<CitaDTO> GetById(int id)
        {
            var cita = await _citaRepository.GetById(id);
            if (cita == null) return null;
            return _mapper.Map<CitaDTO>(cita);
        }

        public async Task<string> Create(CitaDTO citaDto)
        {
            citaDto.Estado = "Pendiente";
            var cita = _mapper.Map<Cita>(citaDto);
            return await _citaRepository.Create(cita);
        }

        public async Task<string> Update(int id, CitaDTO citaDto)
        {
            var cita = _mapper.Map<Cita>(citaDto);
            return await _citaRepository.Update(id, cita);
        }

        public async Task<string> Delete(int id)
        {
            return await _citaRepository.Delete(id);
        }
    }
}