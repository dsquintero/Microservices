using AutoMapper;
using RecetasMicroservice.Api.DTOs;
using RecetasMicroservice.Domain.Entities;
using RecetasMicroservice.Infrastructure.Repository;
using System.Threading.Tasks;

namespace RecetasMicroservice.Application.Services
{
    public class RecetaService : IRecetaService
    {
        private readonly IRecetaRepository _recetaRepository;
        private readonly IMapper _mapper;

        public RecetaService(IRecetaRepository recetaRepository, IMapper mapper)
        {
            _recetaRepository = recetaRepository;
            _mapper = mapper;
        }

        public async Task<RecetaDTO> GetById(int id)
        {
            var receta = await _recetaRepository.GetById(id);
            if (receta == null) return null;
            return _mapper.Map<RecetaDTO>(receta);
        }

        public async Task<string> Create(RecetaDTO recetaDto)
        {
            var receta = _mapper.Map<Receta>(recetaDto);
            return await _recetaRepository.Create(receta);
        }

        public async Task<string> Update(int id, RecetaDTO recetaDto)
        {
            var receta = _mapper.Map<Receta>(recetaDto);
            return await _recetaRepository.Update(id, receta);
        }

        public async Task<string> Delete(int id)
        {
            return await _recetaRepository.Delete(id);
        }
    }
}