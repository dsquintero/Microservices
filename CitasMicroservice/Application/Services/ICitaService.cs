using CitasMicroservice.Api.DTOs;
using System.Threading.Tasks;

namespace CitasMicroservice.Application.Services
{
    public interface ICitaService
    {
        Task<CitaDTO> GetById(int id);
        Task<string> Create(CitaDTO citaDto);
        Task<string> Update(int id, CitaDTO citaDto);
        Task<string> Delete(int id);
    }
}