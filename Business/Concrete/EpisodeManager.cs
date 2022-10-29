using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EpisodeManager : IEpisodeService
    {
        IEpisodeDal _episodeDal;
        public EpisodeManager(IEpisodeDal episodeDal)
        {
            _episodeDal = episodeDal;   
        }

        public IDataResult<List<Episode>> GetAllLastAddedEpisode()
        {
            DateTime lastTwoWeek = DateTime.Today.AddDays(-14);
            return new SuccessDataResult<List<Episode>>(_episodeDal.GetAll(p => p.AddedDate >= lastTwoWeek));

        }

        [SecuredOperation("episode.add,admin")]
        public IResult Add(Episode episode)
        {
            _episodeDal.Add(episode);
            return new SuccessResult(Messages.SeriesAdded);
        }

        [SecuredOperation("episode.update,admin")]
        public IResult Update(Episode episode)
        {
            _episodeDal.Update(episode);
            return new SuccessResult(Messages.EpisodeUpdated);
        }

        [SecuredOperation("episode.delete,admin")]
        public IResult Delete(Episode episode)
        {
            _episodeDal.Delete(episode);
            return new SuccessResult(Messages.EpisodeDeleted);
        }
    }
}
