using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.EntityConfiguration;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class BootcampContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-KVH74IN\SQLEXPRESS; Initial Catalog=BootcampDB;Trusted_Connection=true; Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //Hata verdiği için kapattım.
            modelBuilder.ApplyConfiguration(new CommentConfigurationDal());
            modelBuilder.ApplyConfiguration(new EpisodeConfigurationDal());
            modelBuilder.ApplyConfiguration(new GenreSeriesConfigurationDal());

            //Çoka çok ilişki
            modelBuilder.Entity<GenreSeries>().HasKey(i => new { i.SeriesId, i.GenreId });
            modelBuilder.Entity<GenreSeries>().HasOne<Series>(gs => gs.Series).WithMany(i => i.GenreSeries).HasForeignKey(p => p.SeriesId).OnDelete(DeleteBehavior.ClientSetNull); 
            modelBuilder.Entity<GenreSeries>().HasOne<Genre>(gs => gs.Genre).WithMany(i => i.GenreSeries).HasForeignKey(p => p.GenreId).OnDelete(DeleteBehavior.ClientSetNull);

            //Bire çok ilişki
            modelBuilder.Entity<Comment>().HasOne(i => i.Series).WithMany(p => p.Comments).HasForeignKey(i => i.SeriesId).OnDelete(DeleteBehavior.ClientSetNull); 
            modelBuilder.Entity<Comment>().HasOne(i => i.Episode).WithMany(p => p.Comments).HasForeignKey(i => i.EpisodeId).OnDelete(DeleteBehavior.ClientSetNull);


        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Episode> Episodes { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Season> Seasons { get; set; }

        public DbSet<Series> Series { get; set; }

        public DbSet<GenreSeries> GenreSeries { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; internal set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }



    }
}
