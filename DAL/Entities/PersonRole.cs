using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoproWA.Entities
{
    [Flags]
    public enum PersonRole
    {
        Actor = 1,
        Director = 2,
        Producer = 4
    }
}
