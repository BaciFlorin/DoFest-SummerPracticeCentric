using DoFest.Entities.Activities.Content;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoFest.Persistence.Config.Activity.Content
{
    public class CommentEntityConfig:IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .IsRequired();
        }
    }
}