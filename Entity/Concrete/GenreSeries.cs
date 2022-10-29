using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class GenreSeries
    {

        //composite key  
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }


        public int SeriesId { get; set; }
        public Series? Series { get; set; }
    }
}
