using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<T> AddAsync(T newEntity)
        {
            _dataContext.Set<T>().Add(newEntity);
            await _dataContext.SaveChangesAsync();
            return newEntity;
        }

        public async Task<T> GetDetailAsync(object id)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T updateEntity)
        {
            _dataContext.Set<T>().Update(updateEntity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T deleteEntity)
        {
            _dataContext.Set<T>().Remove(deleteEntity);
            await _dataContext.SaveChangesAsync();
        }
    }
}