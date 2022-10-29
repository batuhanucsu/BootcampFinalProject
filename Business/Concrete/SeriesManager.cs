using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Chaching;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SeriesManager : ISeriesService
    {
        ISeriesDal _seriesDal;
        public SeriesManager(ISeriesDal seriesDal)
        {
            _seriesDal = seriesDal;
        }

        public IDataResult<List<Series>> GetAll()
        {
            return new SuccessDataResult<List<Series>>(_seriesDal.GetAll(), Messages.SeriesIsListed);

        }

        public IDataResult<List<Series>> GetAllByGenreId(int id)
        {
            return new SuccessDataResult<List<Series>>(_seriesDal.GetAll(p => p.GenreSeries.Any(p => p.GenreId == id)));

        }

        public IDataResult<Series> GetBySeriesId(int seriesId)
        {
            return new SuccessDataResult<Series>(_seriesDal.Get(p => p.SeriesId == seriesId));

        }

        public IDataResult<List<Series>> GetAllByIMDb(double min, double max)
        {
            return new SuccessDataResult<List<Series>>(_seriesDal.GetAll(p => p.SeriesIMDb >= min && p.SeriesIMDb <= max));

        }

        public IDataResult<List<Series>> GetAllThisYearSeries()
        {
            return new SuccessDataResult<List<Series>>(_seriesDal.GetAll(p=>p.SeriesYear == DateTime.Now.Year));

        }

        public IDataResult<List<Series>> GetAllBestSeries()
        {
            return new SuccessDataResult<List<Series>>(_seriesDal.GetAll(p => p.SeriesIMDb > 7.0));

        }

        public IDataResult<List<Series>> GetAllByLetter(string letter)
        {
            return new SuccessDataResult<List<Series>>(_seriesDal.GetAll(p => p.SeriesName.StartsWith(letter.ToUpperInvariant())));

        }

        [SecuredOperation("series.delete,admin")]
        public IResult Delete(Series series)
        {
            _seriesDal.Delete(series);
            return new SuccessResult(Messages.SeriesDeleted);
        }

        [SecuredOperation("series.update,admin")]
        public IResult Update(Series series)
        {
            _seriesDal.Update(series);
            return new SuccessResult(Messages.SeriesUpdated);

        }

        [SecuredOperation("series.add,admin")]
        public IResult Add(Series series)
        {
            //IResult result = BusinessRules.Run(/*Buraya iş kuralları metodları çoklu bir şekilde parametre alacak şekilde çağrılıp gönderilir.*/);

            //if (result != null)
            //{
            //    return result;
            //}
            _seriesDal.Add(series);
            return new SuccessResult(Messages.SeriesAdded);
        }
    }
}
