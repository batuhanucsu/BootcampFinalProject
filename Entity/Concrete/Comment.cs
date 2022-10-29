using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }

        public bool IsDeleted { get; set; }

        public int SeriesId { get; set; }
        public Series Series { get; set; }


        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


    }
}
