using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zoolandia.Domain.Models;

namespace Zoolandia.Infrastructure.Configuration;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {

        builder
            .HasKey(p => p.Id);
        
        builder
            .Property(b => b.PetType)
            .HasConversion<string>();
    }
}