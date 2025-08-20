using System.ComponentModel.DataAnnotations.Schema;
using ProjectTracker.Domain.Entities.Base;
using ProjectTracker.Domain.Entities.Base.Interface;
using ProjectTracker.Domain.Entities.Base.Tags;
using TaskStatus = ProjectTracker.Domain.Entities.Base.Tags.TaskStatus;

namespace ProjectTracker.Domain.Entities
{
    public class ProjectTask //: NameEntity, IDescriptionEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.NotStarted;
        public DateTime Deadline { get; set; }

        //Связи

        public int? ParentId { get; set; }
        [ForeignKey(nameof(ParentId))]
        public virtual Project ParentProject { get; set; }
      

        //public string UserId { get; set; }
        //public ApplicationUser User { get; set; }
    }
}
