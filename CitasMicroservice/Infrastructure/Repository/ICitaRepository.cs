using CitasMicroservice.Domain.Entities;
using System.Threading.Tasks;

namespace CitasMicroservice.Infrastructure.Repository
{
    public interface ICitaRepository
    {
        Task<Cita> GetById(int id);
        Task<string> Create(Cita cita);
        Task<string> Update(int id, Cita cita);
        Task<string> Delete(int id);
    }
}