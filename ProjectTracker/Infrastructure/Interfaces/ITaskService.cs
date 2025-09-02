using ProjectTracker.Domain.Entities;

namespace ProjectTracker.Infrastructure.Interfaces
{
    public interface ITaskService
    {
        public ProjectTask GetById(int? id);

        void Add(ProjectTask project);

        void Edit(int id, ProjectTask project);

        void Delete(int id);
    }
}
