using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Season : IEntity
    {
        public int SeasonId { get; set; }
        public int SeasonNumber { get; set; }
        public List<Episode> Episodes { get; set; }

    }
}
