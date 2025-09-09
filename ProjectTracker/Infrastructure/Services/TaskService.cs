using Microsoft.EntityFrameworkCore;
using ProjectTracker.DAL.Context;
using ProjectTracker.Domain.Entities;
using ProjectTracker.Infrastructure.Interfaces;

namespace ProjectTracker.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ProjectTrackerDataBase _db;

        public TaskService(ProjectTrackerDataBase db)
        {
            _db = db;
        }
        public ProjectTask GetById(int? id)
        {
            return _db.Tasks.FirstOrDefault(p => p.Id == id);
        }

        public void Add(ProjectTask task)
        {
            var item = new ProjectTask()
            {
                Id = GetId(_db),
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                ProjectId = task.ProjectId,
                Deadline = task.Deadline,
                Priority = task.Priority
            };
            SaveChanges(item, false);
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

            SaveChanges(item, true);

        }

        public void Delete(int id)
        {
            var item = GetById(id);

            _db.Tasks.Remove(item);

            _db.SaveChanges();
        }

        private void SaveChanges(ProjectTask item, bool isUpdate)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                if (isUpdate)
                {
                    _db.Tasks.Update(item);

                }
                else
                {
                    _db.Tasks.Add(item);

                }

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Tasks] ON");

                _db.SaveChanges();

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Tasks] OFF");

                transaction.Commit();
            }
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
