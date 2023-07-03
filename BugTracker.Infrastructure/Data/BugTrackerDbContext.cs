using BugTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace BugTracker.Infrastructure.Data
{
    public class BugTrackerDbContext : DbContext
    {
        public BugTrackerDbContext(DbContextOptions<BugTrackerDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //create a relationship between entities
          
            modelBuilder.Entity<Bug>()
              .HasOne<Category>(ct => ct.Category)
              .WithMany(x => x.Bugs)
              .HasForeignKey(bu => bu.CategoryID);

            modelBuilder.Entity<Bug>()
                .HasOne<User>(u => u.CreatedBy)
                .WithMany(a => a.Bugs)
                .HasForeignKey(fu => fu.UserID);
           
            
            
        }

        public DbSet<Category> Categories { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<Bug> Bugs { get; set; }    

    }
}
