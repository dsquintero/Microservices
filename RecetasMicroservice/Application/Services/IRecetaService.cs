using System.Threading.Tasks;
using RecetasMicroservice.Application.DTOs;

namespace RecetasMicroservice.Application.Services
{
    public interface IRecetaService
    {
        Task<RecetaDTO> GetById(int id);
        Task<string> Create(RecetaDTO recetaDto);
        Task<string> Update(int id, RecetaDTO recetaDto);
        Task<string> Delete(int id);
    }
}