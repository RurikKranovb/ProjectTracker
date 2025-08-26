using ProjectTracker.Domain.Entities;
using ProjectTracker.ViewModels;

namespace ProjectTracker.Infrastructure.Mapping
{
    public static class ProjectMapping
    {
        public static ProjectViewModel ToView(this Project p) => new ProjectViewModel()
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            StartDate = p.StartDate,
            Status = p.Status,
            
        };

        public static IEnumerable<ProjectViewModel> ToView(this IEnumerable<Project> p) => p.Select(ToView);
    }
}
