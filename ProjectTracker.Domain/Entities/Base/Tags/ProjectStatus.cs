using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Domain.Entities.Base.Tags
{
    public enum ProjectStatus
    {
        [Display(Name = "Актовно")]
        Active,
        [Display(Name = "Выполнено")]
        Completed
    }
}
