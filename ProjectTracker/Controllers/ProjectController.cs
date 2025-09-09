using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectTracker.Infrastructure.Interfaces;
using ProjectTracker.Infrastructure.Mapping;
using ProjectTracker.Infrastructure.Services;
using ProjectTracker.ViewModels;
using TaskStatus = ProjectTracker.Domain.Entities.Base.Tags.TaskStatus;

namespace ProjectTracker.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectData _projectData;
        private readonly ProjectService _projectService;

        public ProjectController(IProjectData projectData, ProjectService projectService)
        {
            _projectData = projectData;
            _projectService = projectService;
        } 

        public IActionResult Index()
        {
            var projects = _projectData.GetProjects().Select(project => project.ToView()).ToList();

            return View(projects);
        }

        public IActionResult Details(int id)
        {
            var project = _projectData.GetTasksById(id);
            if (project is null)
            {
                return NotFound();
            } 

            return View(project.ToView());
        }

        public IActionResult Create(int id)
        {

            var project = new ProjectViewModel();

            ViewBag.Status = Enum.GetValues(typeof(TaskStatus))
                .Cast<TaskStatus>()
                .Select(e => new SelectListItem()
                {
                    Text = e.ToString(),
                });
            return View(new ProjectViewModel());
        }

        [HttpPost]
        public IActionResult Create(ProjectViewModel viewModel)
        {
            if (viewModel is null)
                throw new ArgumentException(nameof(viewModel));

            if (!ModelState.IsValid)
                return View(viewModel);

            _projectService.Add(viewModel.FromView());

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new ProjectViewModel());

            if (id < 0)
                return BadRequest();

            var item = _projectService.GetById(id);

            return View(item.ToView());
        }

        [HttpPost]
        public IActionResult Edit(int id, ProjectViewModel viewModel)
        {
            if (viewModel is null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _projectService.Edit(id, viewModel.FromView());
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id <= 0)
                return BadRequest();

            var item = _projectService.GetById(id);

            if (item is null)
                return NotFound();

            return View(item.ToView());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
