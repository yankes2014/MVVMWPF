using Kino.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbContext _db = new KinoContext();


        public Repository()
        {

        }

        public async Task AddAsync(T item)
        {
            _db.Set<T>().Add(item);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task UpdateAsync(T item, int? id)
        {
            if (id != null)
            {
                var _entity = _db.Set<T>().Find(id);
                if (_entity == null)
                {
                    return;
                }
                _db.Entry(_entity).CurrentValues.SetValues(item);
                _db.Entry(_entity).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            else
            {
                _db.Entry(item).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }


        }
        public async Task<ICollection<T>> GetByFuncAsync(Expression<Func<T, bool>> predicate)
        {
            return await _db.Set<T>().AsNoTracking().Where(predicate).AsNoTracking().ToListAsync();
        }


        public async Task<T> GetById(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<T> GetSingleByFunc(Expression<Func<T, bool>> predicate)
        {
            return await _db.Set<T>().AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public DbEntityEntry<T> Entry(T item)
        {
            return _db.Entry<T>(item);
        }

        public async Task DeleteById(int id)
        {
            var item = await _db.Set<T>().FindAsync(id);
            _db.Set<T>().Remove(item);
            await SaveChangesAsync();
        }
    }
}
