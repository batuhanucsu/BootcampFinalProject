using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EntityConfiguration
{
    public class GenreSeriesConfigurationDal : IEntityTypeConfiguration<GenreSeries>
    {
        public void Configure(EntityTypeBuilder<GenreSeries> builder)
        {
            

        }
    }
}
