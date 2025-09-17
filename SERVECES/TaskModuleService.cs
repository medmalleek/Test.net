using MODULES;
using REPOSITORIES;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SERVECES
{
    public interface ITaskModuleService
    {
        Task<bool> Create(TaskModule entity);
        Task<IEnumerable<TaskModule>> ReadAll();
        Task<TaskModule> ReadById(int id);
        Task<bool> Update(TaskModule entity);
        Task<bool> Delete(TaskModule entity);
        Task<IEnumerable<TaskModule>> Find(Expression<Func<TaskModule, bool>> predicate);

    }
    public class TaskModuleService: ITaskModuleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskModuleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(TaskModule entity)
        {
            _unitOfWork.TaskModuleRepository.Add(entity);
            return await _unitOfWork.Save();
        }

        public async Task<IEnumerable<TaskModule>> ReadAll()
        {
            return (IEnumerable<TaskModule>)await _unitOfWork.TaskModuleRepository.All();
        }

        public async Task<TaskModule> ReadById(int id)
        {
            return await _unitOfWork.TaskModuleRepository.GetById(id);
        }

        public async Task<bool> Update(TaskModule entity)
        {
            _unitOfWork.TaskModuleRepository.Update(entity);
            return await _unitOfWork.Save();
        }

        public async Task<bool> Delete(TaskModule entity)
        {
            _unitOfWork.TaskModuleRepository.Delete(entity);
            return await _unitOfWork.Save();
        }

        public async Task<IEnumerable<TaskModule>> Find(Expression<Func<TaskModule, bool>> predicate)
        {
            return await _unitOfWork.TaskModuleRepository.Find(predicate);
        }

    }
}

