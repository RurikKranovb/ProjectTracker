using ProjectTracker.Domain.Entities.Base.Interface;
using ProjectTracker.Domain.Entities.Base.Tags;
using TaskStatus = ProjectTracker.Domain.Entities.Base.Tags.TaskStatus;

namespace ProjectTracker.ViewModels
{
    public class TaskViewModel : INamedEntity, IDescriptionEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime Deadline { get; set; }

        public int? ProjectId { get; set; }
    }
}
