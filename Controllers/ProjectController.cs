using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class ProjectController : Controller
    {
       private UserManager<User> _userManager;
       private IProjectService _projectService;
        public ProjectController(UserManager<User> userManager , IProjectService projectService)
        {
            _projectService = projectService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()

        {
            var userid = _userManager.GetUserId(User);

            var projects = await _projectService.GetProjectsByCreatorAsync(userid);

            if(projects == null)
            {
                return View(new List<Project>());
            }
            return View(projects);
        }

        
        public IActionResult Create()
        {
            return View("Create",null);
        }
       
        public IActionResult CreateNewProject(ProjectViewModel project)
        {
            var user = _userManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                Project newProject = new Project() { ProjectName = project.ProjectName, ProjectDescription = project.ProjectDescription, CreatedBy = user ,Status =ProjectStatus.NotStarted ,StartDate=project.StartDate, EndDate =project.EndDate };
                _projectService.AddProject(newProject);
                return RedirectToAction("Index");
            }
            return View("Create",project);
        }
        public  IActionResult Details(int id)
        {
            var project =  _projectService.GetProjectById(id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            return View(project);
        }

        public IActionResult Edit(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            ProjectEditViewModel projectEditViewModel = new ProjectEditViewModel() {ProjectDescription=project.ProjectDescription, ProjectId=project.ProjectId , ProjectName=project.ProjectName, EndDate =project.EndDate ,StartDate =project.StartDate, Status=project.Status };
            return View("Edit", projectEditViewModel);
            
        }
        public IActionResult UpdateProject(ProjectEditViewModel projectEditViewModel)
        {
            var user = _userManager.GetUserId(User);
            var project = new Project() { ProjectId = projectEditViewModel.ProjectId, ProjectName = projectEditViewModel.ProjectName, ProjectDescription = projectEditViewModel.ProjectDescription, StartDate = projectEditViewModel.StartDate, EndDate = projectEditViewModel.EndDate, Status = projectEditViewModel.Status ,CreatedBy =user };
            if (projectEditViewModel.ProjectId == 0)
            {
                ModelState.AddModelError("", "Invalid Project ID.");
                return View("Edit", projectEditViewModel);
            }
            if (ModelState.IsValid)
            {
                _projectService.UpdateProject(project);
                return RedirectToAction("Details", new { id = project.ProjectId });
            }
            return View("Edit", projectEditViewModel);
        }

        public IActionResult Delete(int id)
        {
            _projectService.DeleteProject(id);
            return RedirectToAction("Index");
        }


    }
}
