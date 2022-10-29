using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Series : IEntity
    {
        public int SeriesId { get; set; }

        public string SeriesName { get; set; }

        public string Description { get; set; }

        public int SeriesYear { get; set; }

        public double SeriesIMDb { get; set; }

        public string SeriesImage { get; set; }
        public bool IsDeleted { get; set; }


        public List<Episode>? Episodes { get; set; }

        public List<GenreSeries> GenreSeries { get; set; }

        public List<Comment>? Comments { get; set; }



    }
}
