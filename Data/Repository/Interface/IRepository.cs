using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T newEntity);
        Task<T> GetDetailAsync(object id);
        Task<IEnumerable<T>> ListAsync();
        Task UpdateAsync(T updateEntity);
        Task DeleteAsync(T deleteEntity);
    }
}