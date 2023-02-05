using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.MovieId,
                am.ActorId
            });
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actor_Movies).HasForeignKey(m => 
            m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actors).WithMany(am => am.Actor_Movies).HasForeignKey(m => 
            m.ActorId);
        }
       public  DbSet<Actors> Actors { get; set; }
       public  DbSet<Cinema> Cinema { get; set; }
        public DbSet<Actor_Movie> Actor_Movie { get; set; }
        public  DbSet<Movie> Movie { get; set; }
       public  DbSet<Producer> Producer { get; set; }
       
    }
   
}
