using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Domain.Entities.Base;
using ProjectTracker.Domain.Entities.Base.Interface;
using ProjectTracker.Domain.Entities.Base.Tags;

namespace ProjectTracker.Domain.Entities
{
    public class Project : NameEntity, IDescriptionEntity
    {
        public string? Description { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Today;

        public ProjectStatus Status { get; set; } = ProjectStatus.Active;

        //public virtual ICollection<ProjectTask> ProjectTasks { get; set; }


    }
}
