using DoFest.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoFest.Persistence.Config.Identity
{
    public class UserTypeEntityConfig:IEntityTypeConfiguration<UserType>
    {

        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder
                .Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedNever();
        }
    }
}