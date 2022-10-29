using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEpisodeService
    {
        IDataResult<List<Episode>> GetAllLastAddedEpisode();
        IResult Add(Episode episode);
        IResult Update(Episode episode);
        IResult Delete(Episode episode);

    }
}
