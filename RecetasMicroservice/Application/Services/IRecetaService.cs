using RecetasMicroservice.Api.DTOs;
using System.Threading.Tasks;

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