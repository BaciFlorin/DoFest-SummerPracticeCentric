using DoFest.Entities.Activities.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoFest.Persistence.Config.Activity.Content
{
    public class RatingEntityConfig:IEntityTypeConfiguration<Rating>
    {

        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .IsRequired();
        }
    }
}