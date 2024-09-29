using CitasMicroservice.Application.DTOs;
using CitasMicroservice.Domain.Entities;
using System.Threading.Tasks;

namespace CitasMicroservice.Application.Services
{
    public interface ICitaService
    {
        Task<Cita> GetById(int id);
        Task<string> Create(CitaDTO citaDto);
        Task<string> Finish(int id, RecetaDTO recetaDto);
        Task<string> Update(int id, CitaDTO citaDto);
        Task<string> Delete(int id);
    }
}