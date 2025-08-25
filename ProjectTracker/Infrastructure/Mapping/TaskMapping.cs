using ProjectTracker.Domain.Entities;
using ProjectTracker.ViewModels;

namespace ProjectTracker.Infrastructure.Mapping
{
    public static class TaskMapping
    {
        public static TaskViewModel ToView(this ProjectTask p) => new TaskViewModel()
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            ProjectId = p.ProjectId
        };

        public static IEnumerable<TaskViewModel> ToView(this IEnumerable<ProjectTask> p) => p.Select(ToView);
    }
}
