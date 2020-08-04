using DoFest.Entities.Lists;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoFest.Persistence.Config.Lists
{
    public class BucketListActivityEntityConfig:IEntityTypeConfiguration<BucketListActivity>
    {
        public void Configure(EntityTypeBuilder<BucketListActivity> builder)
        {
            builder.HasKey(ba => new { ba.BucketListId, ba.ActivityId });

            builder.HasOne<BucketList>()
                .WithMany(bl => bl.BucketListActivities)
                .HasForeignKey(ba => ba.BucketListId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Entities.Activities.Activity>()
                .WithMany(bl => bl.BucketListActivities)
                .HasForeignKey(ba => ba.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}