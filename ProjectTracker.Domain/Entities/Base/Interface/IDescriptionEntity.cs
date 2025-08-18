using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Domain.Entities.Base.Interface
{
    /// <summary>
    /// Сущность описания
    /// </summary>
    public interface IDescriptionEntity : IBaseEntity
    {
        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }
    }
}
