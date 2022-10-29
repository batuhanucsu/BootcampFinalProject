using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISeriesService
    {
        IDataResult<List<Series>> GetAll();
        IDataResult<List<Series>> GetAllByGenreId(int id);
        IDataResult<List<Series>> GetAllThisYearSeries();
        IDataResult<List<Series>> GetAllByIMDb(double min, double max);
        IDataResult<List<Series>> GetAllBestSeries();
        IDataResult<List<Series>> GetAllByLetter(string letter);
        IDataResult<Series> GetBySeriesId(int seriesId);


        IResult Add(Series series);
        IResult Update(Series series);
        IResult Delete(Series series);

    }
}
