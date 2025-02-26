using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsPlus.Domain.Models;
using static PawsPlus.Domain.Models.ModelConstants.Pet;

namespace PawsPlus.Infrastructure.Configuration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Name)
            .HasMaxLength(MaxNameLength);
        
        builder
            .Property(p => p.Gender)
            .HasMaxLength(MaxGenderLength)
            .HasConversion<string>();

        builder
            .HasMany(p => p.Breeds)
            .WithMany(b => b.Pets);
        
        builder
            .OwnsOne(
                p => p.Age,
                a =>
                {
                    a.Property(a => a.Years).HasColumnName("YearsOld");
                    a.Property(a => a.Months).HasColumnName("MonthsOld");
                });
        
        builder
            .OwnsOne(p => p.Personality,
                p =>
                {
                    p.Property(p => p.Temperament).HasColumnName("Temperament").IsRequired();
                    p.Property(p => p.ActivityLevel).HasColumnName("ActivityLevel").IsRequired();
                    p.Property(p => p.IsTrained).HasColumnName("IsTrained").IsRequired();
                    p.Property(p => p.HasFears).HasColumnName("HasFears").IsRequired();
                    p.Property(p => p.FearsDescription).HasColumnName("FearsDescription").HasMaxLength(MaxDescriptionLength).IsRequired();
                });
        
        builder
            .OwnsOne(p => p.HealthStatus, 
                hs =>
                {
                    hs.Property(hs => hs.IsVaccinated).HasColumnName("IsVaccinated").IsRequired();
                    hs.Property(hs => hs.IsCastrated).HasColumnName("IsCastrated").IsRequired();
                    hs.Property(hs => hs.TakesMedications).HasColumnName("TakesMedications").IsRequired();
                    hs.Property(hs => hs.HasEatingSchedule).HasColumnName("HasEatingSchedule").IsRequired();
                    hs.Property(hs => hs.OtherDietaryNeeds).HasColumnName("OtherDietaryNeeds").HasMaxLength(MaxDescriptionLength).IsRequired();
                    hs.Property(hs => hs.HealthProblems).HasColumnName("HealthProblems").HasMaxLength(MaxDescriptionLength).IsRequired();
                });
        
        builder
            .HasOne(p => p.Weight)
            .WithMany(w => w.Pets)
            .HasForeignKey(p => p.WeightId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}