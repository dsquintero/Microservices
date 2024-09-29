using RecetasMicroservice.Domain.Entities;
using System.Threading.Tasks;

namespace RecetasMicroservice.Infrastructure.Repository
{
    public interface IRecetaRepository
    {
        Task<Receta> GetById(int id);
        Task<string> Create(Receta receta);
        Task<string> Update(int id, Receta receta);
        Task<string> Delete(int id);
    }
}