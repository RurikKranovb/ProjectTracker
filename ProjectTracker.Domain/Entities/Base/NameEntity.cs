using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Domain.Entities.Base.Interface;

namespace ProjectTracker.Domain.Entities.Base
{
    public abstract class NameEntity : BaseEntity, INamedEntity
    {
        [Required]
        public string Name { get; set; }


    }
}
