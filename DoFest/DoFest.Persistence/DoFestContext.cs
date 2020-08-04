using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Places;
using DoFest.Entities.Authentication;
using DoFest.Entities.Authentication.Notification;
using DoFest.Entities.Lists;
using DoFest.Persistence.Config.Activity;
using DoFest.Persistence.Config.Activity.Content;
using DoFest.Persistence.Config.Activity.Places;
using DoFest.Persistence.Config.Identity;
using DoFest.Persistence.Config.Lists;
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
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActivityEntityConfig());
            modelBuilder.ApplyConfiguration(new ActivityTypeEntityConfig());
            modelBuilder.ApplyConfiguration(new CommentEntityConfig());
            modelBuilder.ApplyConfiguration(new PhotoEntityConfig());
            modelBuilder.ApplyConfiguration(new RatingEntityConfig());
            modelBuilder.ApplyConfiguration(new StudentEntityConfig());
            modelBuilder.ApplyConfiguration(new UserEntityConfig());
            modelBuilder.ApplyConfiguration(new CityEntityConfig());
            modelBuilder.ApplyConfiguration(new UserTypeEntityConfig());
            modelBuilder.ApplyConfiguration(new BucketListEntityConfig());
            modelBuilder.ApplyConfiguration(new BucketListActivityEntityConfig());
            modelBuilder.ApplyConfiguration(new NotificationEntityConfig());
        }
    }
}