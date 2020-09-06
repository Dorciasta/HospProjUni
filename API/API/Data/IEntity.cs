using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    /// <summary>
    /// interface implemented by all ef entities
    /// </summary>
    public interface IEntity
    {
        long Id { get; set; }
        bool IsDeleted { get; set; }
    }
}
