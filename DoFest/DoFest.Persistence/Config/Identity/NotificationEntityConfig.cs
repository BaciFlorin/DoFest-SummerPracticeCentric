using DoFest.Entities.Authentication.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoFest.Persistence.Config.Identity
{
    public class NotificationEntityConfig:IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(n => n.Id)
                .IsRequired()
                .ValueGeneratedNever();
        }
    }
}