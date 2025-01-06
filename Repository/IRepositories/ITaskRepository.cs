using WebApplication1.Models;

namespace WebApplication1.Repository.IRepositories
{
    public interface ITaskRepository 
    {
        IQueryable<TaskEntity> GetAll();
        TaskEntity GetById(int id);
        void Add(TaskEntity TaskEntity);
        void Update(TaskEntity TaskEntity);
        void Delete(TaskEntity task);

    }
}
