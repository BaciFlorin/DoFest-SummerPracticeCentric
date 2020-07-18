using DoFest.Entities.Activities;
using DoFest.Entities.Activities.Content;
using DoFest.Entities.Authentication;
using DoFest.Entities.Places;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(p => p.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity.HasMany<Comment>(a => a.Comments)
                    .WithOne(c => c.CActivity)
                    .HasForeignKey(c => c.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany<Note>(a => a.Notes)
                    .WithOne(n => n.NActivity)
                    .HasForeignKey(n => n.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany<Photo>(a => a.Photos)
                    .WithOne(r => r.PActivity)
                    .HasForeignKey(p => p.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany<Rating>(a => a.Ratings)
                    .WithOne(r => r.RActivity)
                    .HasForeignKey(r => r.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<ActivityType>(a => a.AcType)
                    .WithMany(a=>a.Activities)
                    .HasForeignKey(a=>a.ActivityTypeId)
                    .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<ActivityType>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();

                entity.HasMany<Activity>(l => l.Activities)
                    .WithOne(a=>a.AcLocation)
                    .HasForeignKey(a=>a.LocationId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .Property(u => u.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity
                    .HasOne<Student>(u => u.UStudent)
                    .WithOne(u=>u.SUser)
                    .HasForeignKey<User>(u=>u.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasOne<UserType>(u => u.Type)
                    .WithMany(ut => ut.Users)
                    .HasForeignKey(u=>u.UserTypeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany<Comment>(a => a.Comments)
                    .WithOne(c=>c.CUser)
                    .HasForeignKey(c=>c.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany<Note>(a => a.Notes)
                    .WithOne(n=>n.NUser)
                    .HasForeignKey(n=>n.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany<Photo>(a => a.Photos)
                    .WithOne(r=>r.PUser)
                    .HasForeignKey(p=>p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany<Rating>(a => a.Ratings)
                    .WithOne(r=>r.RUser)
                    .HasForeignKey(r=>r.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity
                    .Property(u => u.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

            });

            modelBuilder.Entity<City>(entity =>
            {
                entity
                    .Property(u => u.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                entity
                    .HasMany<Student>(c => c.Students)
                    .WithOne(c=>c.SCity)
                    .HasForeignKey(s=>s.CityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasMany<Location>(c => c.Locations)
                    .WithOne(l=>l.LCity)
                    .HasForeignKey(d=>d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity
                    .Property(u => u.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();
            });


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}