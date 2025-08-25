using ProjectTracker.Domain.Entities.Base.Interface;

namespace ProjectTracker.ViewModels
{
    public class TaskViewModel : INamedEntity, IDescriptionEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? ProjectId { get; set; }
    }
}
