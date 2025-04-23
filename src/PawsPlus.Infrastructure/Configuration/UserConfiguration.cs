using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsPlus.Infrastructure.Identity;

namespace PawsPlus.Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasOne(u => u.Profile)
            .WithOne()
            .HasForeignKey<User>("ProfileId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}