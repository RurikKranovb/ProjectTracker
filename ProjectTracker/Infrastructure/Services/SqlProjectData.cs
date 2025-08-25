using Microsoft.EntityFrameworkCore;
using ProjectTracker.DAL.Context;
using ProjectTracker.Domain.Entities;
using ProjectTracker.Infrastructure.Interfaces;

namespace ProjectTracker.Infrastructure.Services
{
    public class SqlProjectData : IProjectData
    {
        private readonly ProjectTrackerDataBase _db;

        public SqlProjectData(ProjectTrackerDataBase db) => _db = db;

        public IEnumerable<Project> GetProjects()
        {
            return _db.Projects.Select(project => project)
                .AsEnumerable();
        }

        public IEnumerable<ProjectTask> GetTasks()
        {
            return _db.Tasks.Include(task => task.Projects)
                .AsEnumerable();
        }

        public IEnumerable<ProjectTask> GetTasksById(int id)
        {
            IQueryable<ProjectTask> query = _db.Tasks;

            query = query.Where(task => task.ProjectId == id);

            return query.AsEnumerable();
        }
    }
}
