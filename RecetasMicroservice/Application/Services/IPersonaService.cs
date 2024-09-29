using System.Threading.Tasks;
using RecetasMicroservice.Application.DTOs;

namespace RecetasMicroservice.Application.Services
{
    public interface IPersonaService
    {
        Task<PersonaDTO> GetByIdentificacion(int TipoPersona, string Identificacion);
    }
}