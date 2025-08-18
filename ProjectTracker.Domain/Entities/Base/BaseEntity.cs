using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTracker.Domain.Entities.Base.Interface;

namespace ProjectTracker.Domain.Entities.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Уникальный для таблицы
        public int Id { get; set; }
    }
}
