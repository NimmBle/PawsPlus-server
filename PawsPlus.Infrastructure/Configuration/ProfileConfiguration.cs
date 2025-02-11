using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            .IsRequired();
        
        builder
            .Property(p => p.LastName)
            .IsRequired();
        
        builder
            .Property(p => p.PhoneNumber)
            .IsRequired();

        builder
            .Property(p => p.PhotoUrl)
            .IsRequired(false);
        
        builder
            .Property(p => p.Description)
            .IsRequired(false);



        builder
            .OwnsOne(p => p.Location, opt =>
            {
                opt.Property(l => l.Point)
                    .HasColumnType("geometry");
            });
        
        builder
            .HasOne(p => p.Pet)
            .WithOne(p => p.Profile);

        builder
            .HasOne(p => p.Post)
            .WithOne(p => p.Profile);

        // builder
        //     .HasOne(p => p.Meeting)
        //     .WithOne(p => p.Profile);
    }
}