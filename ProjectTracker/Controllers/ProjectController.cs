using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Infrastructure.Interfaces;

namespace ProjectTracker.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectData _projectData;

        public ProjectController(IProjectData projectData) => _projectData = projectData;

        public IActionResult Index()
        {
            var project = _projectData.GetProjects();

            return View();
        }
    }
}
