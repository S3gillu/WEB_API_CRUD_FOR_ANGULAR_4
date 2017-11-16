using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listing1.ENTITIES
{
    public interface IEntityBase
    {
        long Id { get; set; }

        bool? IsDeleted { get; set; }
    }
}
