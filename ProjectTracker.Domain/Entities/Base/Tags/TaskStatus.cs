using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Domain.Entities.Base.Tags
{
    public enum TaskStatus
    {
        [Display(Name = "Не начато")]
        NotStarted,
        [Display(Name = "В процессе")]
        InProgress,
        [Display(Name = "Выполнено")]
        Completed
    }
}
