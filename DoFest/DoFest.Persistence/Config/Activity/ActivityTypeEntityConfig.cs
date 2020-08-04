using DoFest.Entities.Activities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoFest.Persistence.Config.Activity
{
    public class ActivityTypeEntityConfig: IEntityTypeConfiguration<ActivityType>
    {

        public void Configure(EntityTypeBuilder<ActivityType> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .IsRequired();
        }
    }
}