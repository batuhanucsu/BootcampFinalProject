using Business.Abstract;
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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }

        public IDataResult<List<Comment>> GetAllByEpisodeId(int episodeId)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(p=>p.EpisodeId == episodeId));

        }

        public IDataResult<List<Comment>> GetAllBySeriesId(int seriesId)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(p => p.SeriesId == seriesId));

        }
    }
}
