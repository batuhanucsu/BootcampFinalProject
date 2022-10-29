using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Episode : IEntity
    {
        public int EpisodeId { get; set; }
        public int EpisodeNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime AddedDate { get; set; }

        public int SeasonId { get; set; }
        public Season? Season { get; set; }

        public int SeriesId { get; set; }
        public Series? Series { get; set; }

        public List<Comment>? Comments { get; set; }

    }
}
