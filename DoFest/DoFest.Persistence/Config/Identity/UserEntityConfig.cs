using DoFest.Entities.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoFest.Persistence.Config.Identity
{
    public class UserEntityConfig:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedNever();

            builder
                .HasIndex(u => u.Username)
                .IsUnique();

            builder
                .HasIndex(u => u.Email)
                .IsUnique();


            builder
                .HasOne(u=>u.Student)
                .WithOne()
                .HasForeignKey<User>(u => u.StudentId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne<UserType>()
                .WithMany(ut => ut.Users)
                .HasForeignKey(u => u.UserTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Comments)
                .WithOne()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(a => a.Photos)
                .WithOne()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Ratings)
                .WithOne()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}