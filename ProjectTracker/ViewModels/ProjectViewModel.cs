using ProjectTracker.Domain.Entities.Base.Interface;

namespace ProjectTracker.ViewModels
{
    public class ProjectViewModel: INamedEntity, IDescriptionEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public List<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
    }
}
