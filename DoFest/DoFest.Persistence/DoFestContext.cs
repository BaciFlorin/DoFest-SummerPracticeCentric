using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Content;
using DoFest.Entities.Activities.Places;
using DoFest.Entities.Authentication;
using DoFest.Entities.Authentication.Notification;
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

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<BucketList> BucketLists { get; set; }
        public DbSet<BucketListActivity> BucketListActivities { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(p => p.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                entity.HasMany(a => a.Comments)
                    .WithOne(c => c.Activity)
                    .HasForeignKey(c => c.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.Notes)
                    .WithOne(n => n.Activity)
                    .HasForeignKey(n => n.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.Photos)
                    .WithOne(r => r.Activity)
                    .HasForeignKey(p => p.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.Ratings)
                    .WithOne(r => r.Activity)
                    .HasForeignKey(r => r.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.AcType)
                    .WithMany(a=>a.Activities)
                    .HasForeignKey(a=>a.ActivityTypeId)
                    .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .IsRequired();
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .IsRequired();
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .IsRequired();
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .IsRequired();
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .IsRequired();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .IsRequired();

                entity.HasMany(l => l.Activities)
                    .WithOne(a=>a.Location)
                    .HasForeignKey(a=>a.LocationId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .Property(u => u.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                entity
                    .HasOne(u => u.Student)
                    .WithOne(u=>u.User)
                    .HasForeignKey<User>(u=>u.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasOne(u => u.UserType)
                    .WithMany(ut => ut.Users)
                    .HasForeignKey(u=>u.UserTypeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.Comments)
                    .WithOne(c=>c.User)
                    .HasForeignKey(c=>c.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.Notes)
                    .WithOne(n=>n.User)
                    .HasForeignKey(n=>n.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.Photos)
                    .WithOne(r=>r.User)
                    .HasForeignKey(p=>p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.Ratings)
                    .WithOne(r=>r.User)
                    .HasForeignKey(r=>r.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity
                    .Property(u => u.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

            });

            modelBuilder.Entity<City>(entity =>
            {
                entity
                    .Property(u => u.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                entity
                    .HasMany(c => c.Students)
                    .WithOne(c=>c.City)
                    .HasForeignKey(s=>s.CityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasMany(c => c.Locations)
                    .WithOne(l=>l.City)
                    .HasForeignKey(d=>d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity
                    .Property(u => u.Id)
                    .IsRequired()
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<BucketList>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                entity.HasOne(b => b.User)
                    .WithOne(u => u.BucketList)
                    .HasForeignKey<BucketList>(b => b.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BucketListActivity>(entity =>
            {
                entity.HasKey(ba => new { ba.BucketListId, ba.ActivityId});

                entity.HasOne(ba => ba.BucketList)
                    .WithMany(bl => bl.BucketListActivities)
                    .HasForeignKey(ba => ba.BucketListId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ba => ba.Activity)
                    .WithMany(bl => bl.BucketListActivities)
                    .HasForeignKey(ba => ba.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(n => n.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                entity.HasOne(n => n.User)
                    .WithMany(u => u.Notifications)
                    .HasForeignKey(n => n.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}