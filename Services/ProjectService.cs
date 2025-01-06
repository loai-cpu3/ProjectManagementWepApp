using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repository.IRepositories;

namespace WebApplication1.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void AddProject(Project project)
        {
            _projectRepository.Add(project);
        }

        public void DeleteProject(int projectId)
        {
            var project = _projectRepository.GetById(projectId);
            if (project != null)
            {
                _projectRepository.Delete(project);
            }
        }

        public List<Project> GetAllProjects()
        {
            return _projectRepository.GetAll().ToList();
        }

        public Project GetProjectById(int projectId)
        {
            return _projectRepository.GetById(projectId);
        }

        public void UpdateProject(Project project)
        {
            _projectRepository.Update(project);
        }
        public async Task<List<Project>> GetProjectsByCreatorAsync(string userId)
        {
            return await _projectRepository.GetProjectsByCreatorAsync(userId);
        }
    }
}
