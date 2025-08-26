using Microsoft.EntityFrameworkCore;
using ProjectTracker.DAL.Context;
using ProjectTracker.Domain.Entities;
using ProjectTracker.Domain.Entities.Base.Tags;
using ProjectTracker.Infrastructure.Interfaces;

namespace ProjectTracker.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectTrackerDataBase _db;

        public ProjectService(ProjectTrackerDataBase db)
        {
            _db = db;
        }
        public void Add(Project project)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                var item = new Project()
                {
                    Id = GetId(_db),
                    Name = project.Name,
                    Status = project.Status = ProjectStatus.Active,
                    Description = project.Description,
                    StartDate = project.StartDate = DateTime.Now,
                };

                _db.Projects.Add(item);

                 _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Projects] ON");

                _db.SaveChanges();

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Projects] OFF");

                transaction.Commit();
            }
        }

        public void Edit(int id, Project project)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        private int GetId(ProjectTrackerDataBase db)
        {
            var usedIds = db.Projects
                .OrderBy(p => p.Id)
                .Select(p => p.Id)
                .ToList();

            int expectedId = 1;

            foreach (var usedId in usedIds)
            {
                if (usedId > expectedId)
                {
                    return expectedId;
                }
                expectedId++;
            }
            return expectedId;
        }

    }
}
