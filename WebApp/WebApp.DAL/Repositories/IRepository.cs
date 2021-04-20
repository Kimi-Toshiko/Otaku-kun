using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        bool Exists(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
    }
}
