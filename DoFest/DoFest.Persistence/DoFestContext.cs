using System.Reflection;
using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Places;
using DoFest.Entities.Authentication;
using DoFest.Entities.Lists;
using Microsoft.EntityFrameworkCore;

namespace DoFest.Persistence
{
    public sealed class DoFestContext:DbContext
    {
        public DoFestContext(DbContextOptions<DoFestContext> options):base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<BucketList> BucketLists { get; set; }
        public DbSet<BucketListActivity> BucketListActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Seed();
        }
    }
}