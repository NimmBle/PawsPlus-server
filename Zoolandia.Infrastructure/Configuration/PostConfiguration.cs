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
        // var petTypeConverter = new ValueConverter<HashSet<PetType>, string>(
        //     v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
        //     v => JsonSerializer.Deserialize<HashSet<PetType>>(v, (JsonSerializerOptions?)null) ?? new HashSet<PetType>()
        // );
        //
        // var weightTypeConverter = new ValueConverter<HashSet<Weight>, string>(
        //     v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
        //     v => JsonSerializer.Deserialize<HashSet<Weight>>(v, (JsonSerializerOptions?)null) ?? new HashSet<Weight>()
        // );
        //
        // builder
        //     .Property(typeof(HashSet<PetType>), "_types")
        //     .HasConversion(petTypeConverter, new ValueComparer<>())
        //     .HasColumnName("Pets");
        //
        // builder
        //     .Property(typeof(HashSet<Weight>), "_weights")
        //     .HasConversion(weightTypeConverter)
        //     .HasColumnName("Weights");
        
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