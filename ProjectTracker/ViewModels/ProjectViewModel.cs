using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Domain.Entities.Base.Interface;
using ProjectTracker.Domain.Entities.Base.Tags;

namespace ProjectTracker.ViewModels
{
    public class ProjectViewModel: INamedEntity, IDescriptionEntity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательное поле")]
        public string? Name { get; set; }

        [Display(Name = "Опесание")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательное поле")]
        public string? Description { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public ProjectStatus Status { get; set; } = ProjectStatus.Active;

        //public List<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
    }
}
