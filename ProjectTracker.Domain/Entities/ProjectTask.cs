using System.ComponentModel.DataAnnotations.Schema;
using ProjectTracker.Domain.Entities.Base;
using ProjectTracker.Domain.Entities.Base.Interface;
using ProjectTracker.Domain.Entities.Base.Tags;
using TaskStatus = ProjectTracker.Domain.Entities.Base.Tags.TaskStatus;

namespace ProjectTracker.Domain.Entities
{
    public class ProjectTask : NameEntity, IDescriptionEntity
    {
        public string Description { get; set; }

        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.NotStarted;

        public DateTime Deadline { get; set; }

        //Связи

        public int ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }

        //public string UserId { get; set; }
        //public ApplicationUser User { get; set; }
    }
}
