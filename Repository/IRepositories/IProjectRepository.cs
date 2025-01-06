using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repository.IRepositories
{
    public interface IProjectRepository
    {
        IQueryable<Project> GetAll();
        Project GetById(int id);
        void Add(Project project);
        void Update(Project project);
        void Delete(Project project);
        public Task<List<Project>> GetProjectsByCreatorAsync(string userId);
       
    }
}
