using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static PawsPlus.Domain.Models.ModelConstants.Common;
using static PawsPlus.Domain.Models.ModelConstants.Profile;
using PawsPlus.Domain.Models;

namespace PawsPlus.Infrastructure.Configuration;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder
            .HasKey(p => p.Id);
        
        builder
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(p => p.FirstName)
            .HasMaxLength(MaxNameLength)
            .IsRequired();
        
        builder
            .Property(p => p.LastName)
            .HasMaxLength(MaxNameLength)
            .IsRequired();
        
        builder
            .Property(p => p.PhoneNumber)
            .HasMaxLength(MaxPhoneNumberLength)
            .IsRequired();

        builder
            .Property(p => p.PhotoUrl)
            .HasMaxLength(MaxUrlLength)
            .IsRequired(false);
        
        builder
            .Property(p => p.Description)
            .HasMaxLength(MaxDescriptionLength)
            .IsRequired(false);

        
        builder
            .OwnsOne(p => p.Location, opt =>
            {
                opt.Property(l => l.Point)
                    .HasColumnType("geometry");
            });
        
        builder
            .HasOne(p => p.Pet)
            .WithOne(p => p.Profile)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(p => p.Post)
            .WithOne(p => p.Profile)
            .OnDelete(DeleteBehavior.Cascade);

        // builder
        //     .HasOne(p => p.Meeting)
        //     .WithOne(p => p.Profile);
    }
}