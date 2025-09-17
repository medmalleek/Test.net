using Microsoft.EntityFrameworkCore;
using REPOSITORIES.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORIES
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(int id);
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ContextDB _context;
        protected DbSet<T> dbSet;

        public GenericRepository(ContextDB context)
        {
            this.dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual bool Add(T entity)
        {
            dbSet.Add(entity);
            return true;
        }

        public virtual bool Delete(T entity)
        {
            dbSet.Remove(entity);
            return true;
        }

        public virtual bool Update(T entity)
        {
            dbSet.Update(entity);
            return true;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
    }
}
