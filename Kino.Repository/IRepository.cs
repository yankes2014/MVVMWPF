using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Repository
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T item);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync(T item, int? id);
        Task<ICollection<T>> GetByFuncAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetSingleByFunc(Expression<Func<T, bool>> predicate);
        Task<T> GetById(int id);
        Task SaveChangesAsync();
        DbEntityEntry<T> Entry(T entity);
        Task DeleteById(int id);
    }
}
