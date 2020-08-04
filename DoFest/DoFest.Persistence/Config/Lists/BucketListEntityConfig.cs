using DoFest.Entities.Authentication;
using DoFest.Entities.Lists;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoFest.Persistence.Config.Lists
{
    public class BucketListEntityConfig:IEntityTypeConfiguration<BucketList>
    {
        public void Configure(EntityTypeBuilder<BucketList> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder.HasOne<User>()
                .WithOne()
                .HasForeignKey<BucketList>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}