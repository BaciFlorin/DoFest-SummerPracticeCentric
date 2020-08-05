using DoFest.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoFest.Persistence.Config.Identity
{
    public class StudentEntityConfig:IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedNever();
        }
    }
}