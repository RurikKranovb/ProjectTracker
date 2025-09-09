using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Infrastructure.Interfaces;
using ProjectTracker.Infrastructure.Mapping;
using ProjectTracker.Infrastructure.Services;
using ProjectTracker.ViewModels;

namespace ProjectTracker.Controllers
{
    public class TaskController : Controller
    {

        private readonly IProjectData _projectData;
        private readonly TaskService _taskService;

        public TaskController(IProjectData projectData, TaskService taskService)
        {
            _projectData = projectData;
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            var task = _projectData.GetTasks();

            return View(task.ToView());
        }

        public IActionResult Create(int id)
        {
            return View(new TaskViewModel());
        }

        [HttpPost]
        public IActionResult Create(TaskViewModel viewModel)
        {
            if (viewModel is null)
                throw new ArgumentNullException(nameof(viewModel));

            if (!ModelState.IsValid)
                return View(viewModel);

            _taskService.Add(viewModel.FromView());


            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new TaskViewModel());

            if (id < 0)
                return BadRequest();

            var item = _taskService.GetById(id);
            return View(item.ToView());
        }

        [HttpPost]
        public IActionResult Edit(int id, TaskViewModel viewModel)
        {
            if (viewModel is null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _taskService.Edit(id, viewModel.FromView());
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id <= 0)
                return BadRequest();

            var item = _taskService.GetById(id);

            if (item is null)
                return NotFound();

            return View(item.ToView());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _taskService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
