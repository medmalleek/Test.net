using MODULES;
using REPOSITORIES.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORIES
{
    public interface IUnitOfWork
    {
        IGenericRepository<TaskModule> TaskModuleRepository { get; }
        Task<bool> Save();
    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public readonly ContextDB contextDB;
        public IGenericRepository<TaskModule> TaskModuleRepository { get;}
        public UnitOfWork(ContextDB context)
        {
            contextDB = context;
            TaskModuleRepository = new GenericRepository<TaskModule>(contextDB);
        }

        public void Dispose()
        {
            contextDB.Dispose();
        }

        public async Task<bool> Save()
        {
            try
            {
                await contextDB.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
