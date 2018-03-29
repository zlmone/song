using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WSH.Manager.Models
{
    public class Entity : IEntity
    {
        public virtual string Id { get; set; }
    }
}
