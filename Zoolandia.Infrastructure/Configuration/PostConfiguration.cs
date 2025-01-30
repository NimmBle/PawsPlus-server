using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zoolandia.Domain.Enums.Pet;
using Zoolandia.Domain.Models;

namespace Zoolandia.Infrastructure.Configuration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
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