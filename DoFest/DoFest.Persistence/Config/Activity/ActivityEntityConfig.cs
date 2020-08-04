using DoFest.Entities.Activities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoFest.Persistence.Config.Activity
{
    public class ActivityEntityConfig: IEntityTypeConfiguration<Entities.Activities.Activity>
    {
        public void Configure(EntityTypeBuilder<Entities.Activities.Activity> builder)
        {
            builder.Property(p => p.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

            builder.HasMany(a => a.Comments)
                    .WithOne()
                    .HasForeignKey(c => c.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Photos)
                    .WithOne()
                    .HasForeignKey(p => p.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Ratings)
                    .WithOne()
                    .HasForeignKey(r => r.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<ActivityType>()
                    .WithMany(a => a.Activities)
                    .HasForeignKey(a => a.ActivityTypeId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Notifications)
                    .WithOne()
                    .HasForeignKey(n => n.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}