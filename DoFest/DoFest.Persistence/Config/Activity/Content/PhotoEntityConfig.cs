using DoFest.Entities.Activities.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoFest.Persistence.Config.Activity.Content
{
    public class PhotoEntityConfig:IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .IsRequired();
        }
    }
}