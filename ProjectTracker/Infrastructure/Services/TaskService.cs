using Microsoft.EntityFrameworkCore;
using ProjectTracker.DAL.Context;
using ProjectTracker.Domain.Entities;
using ProjectTracker.Infrastructure.Interfaces;

namespace ProjectTracker.Infrastructure.Services
{
    public class TaskService : BaseService<ProjectTask>
    {

        private const string Tasks = "Tasks";

        public TaskService(ProjectTrackerDataBase db): base(db) { }

        protected override DbSet<ProjectTask> DbSet => _db.Tasks;

        public void Add(ProjectTask task)
        {
            var item = new ProjectTask()
            {
                Id = GetId(),
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                ProjectId = task.ProjectId,
                Deadline = task.Deadline,
                Priority = task.Priority
            };
            SaveChanges(item, false,Tasks);
        }

        public void Edit(int id, ProjectTask task)
        {
            var item = GetById(id);

            item.Name = task.Name;
            item.Description = task.Description;
            item.Status = task.Status;
            item.ProjectId = task.ProjectId;
            item.Deadline = task.Deadline;
            item.Priority = task.Priority;

            SaveChanges(item, true, Tasks);

        }
    }
}
