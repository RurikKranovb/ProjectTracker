using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Infrastructure.Interfaces;
using ProjectTracker.Infrastructure.Mapping;

namespace ProjectTracker.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectData _projectData;

        public ProjectController(IProjectData projectData) => _projectData = projectData;

        public IActionResult Index()
        {
            var ss = _projectData.GetProjects().Select(project => project.ToView()).ToList();

            return View(ss);
        }

        public IActionResult Details(int id)
        {
            var project = _projectData.GetTasksById(id).Select(task => task.ToView()).ToList();

            return View(project);
        }
    }
}
