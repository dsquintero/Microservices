using System.Threading.Tasks;
using CitasMicroservice.Application.DTOs;

namespace CitasMicroservice.Application.Services
{
    public interface IPersonaService
    {
        Task<PersonaDTO> GetByIdentificacion(int TipoPersona, string Identificacion);
    }
}