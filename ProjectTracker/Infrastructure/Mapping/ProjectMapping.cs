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

        public static Project FromView(this ProjectViewModel p) => new Project()
        {
            Id = p.Id,
            Status = p.Status,
            StartDate = p.StartDate,
            Name = p.Name,
            Description = p.Description
        };
    }
}
