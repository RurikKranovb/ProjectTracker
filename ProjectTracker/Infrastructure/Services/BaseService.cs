using Microsoft.EntityFrameworkCore;
using ProjectTracker.DAL.Context;
using ProjectTracker.Domain.Entities.Base;
using ProjectTracker.Infrastructure.Interfaces;

namespace ProjectTracker.Infrastructure.Services
{
    public abstract class BaseService<T> where T : BaseEntity
    {
        protected readonly ProjectTrackerDataBase _db;
        protected abstract DbSet<T> DbSet { get; }

        protected BaseService(ProjectTrackerDataBase db)
        {
            _db = db;
        }

        public T GetById(int? id) => DbSet.FirstOrDefault(d => d.Id == id);

        public void Delete(int? id)
        {
            var item = GetById(id);
            if (item is null) return;
            DbSet.Remove(item);
            _db.SaveChanges();
        }

        protected void SaveChanges(T item, bool isUpdate, string tableName)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                if (isUpdate)
                {
                    DbSet.Update(item);
                }
                else
                {
                    DbSet.Add(item);
                }
                _db.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [dbo].[{tableName}] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [dbo].[{tableName}] OFF");
                transaction.Commit();
            }
        }

        protected int GetId()
        {
            var usedIds = DbSet
                .OrderBy(d => d.Id)
                .Select(d => d.Id)
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
