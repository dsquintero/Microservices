using RecetasMicroservice.Application.DTOs;
using System.Threading.Tasks;

namespace RecetasMicroservice.Application.Services
{
    public interface ICitaService
    {
        Task<CitaDTO> GetById(int id);
    }
}