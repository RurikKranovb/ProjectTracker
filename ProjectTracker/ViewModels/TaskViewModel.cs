using ProjectTracker.Domain.Entities.Base.Interface;
using ProjectTracker.Domain.Entities.Base.Tags;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TaskStatus = ProjectTracker.Domain.Entities.Base.Tags.TaskStatus;

namespace ProjectTracker.ViewModels
{
    public class TaskViewModel : INamedEntity, IDescriptionEntity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательное поле")]
        public string? Name { get; set; }

        [Display(Name = "Опесание")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательное поле")]
        public string? Description { get; set; }

        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime Deadline { get; set; }

        public int? ProjectId { get; set; }
    }
}
