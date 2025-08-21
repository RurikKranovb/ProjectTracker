using ProjectTracker.Domain.Entities;

namespace ProjectTracker.Infrastructure.Interfaces
{
    /// <summary>
    /// Каталог проектов
    /// </summary>
    public interface IProjectData
    {
        /// <summary>
        /// Получить все проекты
        /// </summary>
        /// <returns></returns>
        IEnumerable<Project> GetProjects();

        /// <summary>
        /// Получить все задачи
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProjectTask> GetTasks();
    }
}
