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
    public class EpisodeConfigurationDal : IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.HasKey(x => x.EpisodeId);
            builder.Property(x => x.EpisodeId).UseIdentityColumn();
            builder.HasOne<Season>(p => p.Season).WithMany(p => p.Episodes).HasForeignKey(p => p.SeasonId);
            builder.HasOne<Series>(t=>t.Series).WithMany(t => t.Episodes).HasForeignKey(t => t.SeriesId);
        }
    }
}
