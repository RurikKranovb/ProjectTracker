using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTracker.Domain.Entities.Base.Interface
{
    /// <summary>
    /// Именованная сущность
    /// </summary>
    public interface INamedEntity : IBaseEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }
    }
}
