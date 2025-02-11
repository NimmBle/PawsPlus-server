using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsPlus.Domain.Models;

namespace PawsPlus.Infrastructure.Configuration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .HasKey(p => p.Id);
        
        // builder
        //     .Property(p => p.PetTypes)
        //     .HasConversion(new EnumToStringConverter<PetType>());
        //
        // builder
        //     .Property(p => p.Weights)
        //     .HasConversion(new EnumToStringConverter<Weight>());
        
        builder
            .HasMany(p => p.Services)
            .WithOne(s => s.Post)
            .HasForeignKey(s => s.PostId);
        //
        // builder
        //     .UsePropertyAccessMode(PropertyAccessMode.Field);
        
        builder
            .OwnsOne(p => p.Status,
                s =>
                {
                    s.WithOwner();

                    s.Property(s => s.Value);
                });
    }
}