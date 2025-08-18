using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Domain.Entities.Base.Interface
{
    /// <summary>
    /// Базовая сущность
    /// </summary>
    public interface IBaseEntity
    {
        /// <summary>
        /// Индентификатор
        /// </summary>
        int Id { get; set; }
    }
}
