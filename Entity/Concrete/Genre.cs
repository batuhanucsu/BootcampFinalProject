using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public  class Genre : IEntity
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public bool IsDeleted { get; set; }


        public ICollection<GenreSeries> GenreSeries { get; set; }

    }
}
