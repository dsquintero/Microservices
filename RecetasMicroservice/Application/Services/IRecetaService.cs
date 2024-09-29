using System.Collections.Generic;
using System.Threading.Tasks;
using RecetasMicroservice.Api.DTOs;

namespace RecetasMicroservice.Application.Services
{
    public interface IRecetaService
    {
        Task<List<RecetaDTO>> GetAll();
        Task<RecetaDTO> GetById(int id);
        Task<string> Create(int idTipoPersona, RecetaDTO personaDto);
        Task<string> Update(int id, RecetaDTO personaDto);
        Task<string> Delete(int id);
    }
}