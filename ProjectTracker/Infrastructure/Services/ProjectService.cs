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

        public Project GetById(int? id)
        {
            return _db.Projects.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Project project)
        {
            var item = new Project()
            {
                Id = GetId(_db),
                Name = project.Name,
                Status = project.Status = ProjectStatus.Active,
                Description = project.Description,
                StartDate = project.StartDate = DateTime.Now,
            };

            SaveChanges(item, false);

        }

        public void Edit(int id, Project project)
        {
            var item = GetById(id);


            item.Name = project.Name;
            item.Status = project.Status = ProjectStatus.Active;
            item.StartDate = project.StartDate = DateTime.Today;
            item.Description = project.Description;


            SaveChanges(item, true);

        }

        private void SaveChanges(Project item, bool isUpdate)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                if (isUpdate)
                {
                    _db.Projects.Update(item);

                }
                else
                {
                    _db.Projects.Add(item);

                }

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Projects] ON");

                _db.SaveChanges();

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Projects] OFF");

                transaction.Commit();
            }
        }

        public void Delete(int id)
        {
            var item = GetById(id);

            _db.Projects.Remove(item);

            _db.SaveChanges();

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
