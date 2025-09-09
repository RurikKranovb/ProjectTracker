using Microsoft.EntityFrameworkCore;
using ProjectTracker.DAL.Context;
using ProjectTracker.Domain.Entities;
using ProjectTracker.Domain.Entities.Base.Tags;
using ProjectTracker.Infrastructure.Interfaces;

namespace ProjectTracker.Infrastructure.Services
{
    public class ProjectService : BaseService<Project>
    {
        private const string Projects = "Projects";

        public ProjectService(ProjectTrackerDataBase db) : base(db){}


        protected override DbSet<Project> DbSet => _db.Projects;

        public void Add(Project project)
        {
            var item = new Project()
            {
                Id = GetId(),
                Name = project.Name,
                Status = project.Status = ProjectStatus.Active,
                Description = project.Description,
                StartDate = project.StartDate = DateTime.Now,
            };

            SaveChanges(item, false, Projects);

        }

        public void Edit(int id, Project project)
        {
            var item = GetById(id);


            item.Name = project.Name;
            item.Status = project.Status = ProjectStatus.Active;
            item.StartDate = project.StartDate = DateTime.Today;
            item.Description = project.Description;


            SaveChanges(item, true, Projects);

        }
    }
}
