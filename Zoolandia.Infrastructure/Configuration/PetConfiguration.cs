using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zoolandia.Domain.Models;

namespace Zoolandia.Infrastructure.Configuration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder
            .OwnsOne(p => p.Age);
        
        builder
            .OwnsOne(p => p.Personality);
        
        builder
            .OwnsOne(p => p.HealthStatus);
    }
}