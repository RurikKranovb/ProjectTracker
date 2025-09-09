using ProjectTracker.Domain.Entities;
using ProjectTracker.Models;

namespace ProjectTracker.Infrastructure.Interfaces
{
    public interface IProjectService
    {
        public Project GetById(int? id);

        void Add(Project project);

        void Edit(int id, Project project);

        void Delete(int id);
    }
}
