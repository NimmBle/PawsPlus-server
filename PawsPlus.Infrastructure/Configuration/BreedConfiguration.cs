using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsPlus.Domain.Models;

namespace PawsPlus.Infrastructure.Configuration;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {

        builder
            .HasKey(p => p.Id);

        builder
            .HasOne(b => b.Animal)
            .WithMany(a => a.Breeds)
            .HasForeignKey(b => b.AnimalTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // builder
        //     .Property(b => b.PetType)
        //     .HasConversion<string>();
        
        
    }
}