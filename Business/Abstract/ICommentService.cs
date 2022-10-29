using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetAllBySeriesId(int id);
        IDataResult<List<Comment>> GetAllByEpisodeId(int id);
        IResult Add(Comment comment);

    }
}
