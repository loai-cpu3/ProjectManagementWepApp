using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IProjectService
    {
        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int projectId);
        Project GetProjectById(int projectId);
        List<Project> GetAllProjects();
        public Task<List<Project>> GetProjectsByCreatorAsync(string userId);
    }
}
