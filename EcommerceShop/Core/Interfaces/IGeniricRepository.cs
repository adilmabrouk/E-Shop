using Core.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGeniricRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id); 
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> ListAllAsync(ISpecification<T> spec);

        Task<T> GetEntityWithSpecAsync(ISpecification<T> spec);
    }

}
