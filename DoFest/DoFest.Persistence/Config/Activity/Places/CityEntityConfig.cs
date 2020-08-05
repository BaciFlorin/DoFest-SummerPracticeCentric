using DoFest.Entities.Activities.Places;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoFest.Persistence.Config.Activity.Places
{
    public class CityEntityConfig:IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
                .Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder
                .HasMany(c => c.Students)
                .WithOne()
                .HasForeignKey(s => s.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasMany(c => c.Activities)
                .WithOne()
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}