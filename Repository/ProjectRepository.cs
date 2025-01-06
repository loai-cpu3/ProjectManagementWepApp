using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository.IRepositories;

namespace WebApplication1.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void Delete(Project project)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        public IQueryable<Project> GetAll()
        {
            return _context.Projects;
        }

        public Project GetById(int id)
        {
            return _context.Projects.FirstOrDefault(p => p.ProjectId == id)?? new Project() { ProjectId=0};
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }
        public async Task<List<Project>> GetProjectsByCreatorAsync(string userId)
        {
            return await _context.Projects
                .Where(p => p.CreatedBy == userId)
                .ToListAsync();
        }
    }
}
