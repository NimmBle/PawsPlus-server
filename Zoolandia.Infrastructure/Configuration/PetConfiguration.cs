using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zoolandia.Domain.Models;

namespace Zoolandia.Infrastructure.Configuration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
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
                    p.Property(p => p.Temperament).HasColumnName("Temperament");
                    p.Property(p => p.ActivityLevel).HasColumnName("ActivityLevel");
                    p.Property(p => p.IsTrained).HasColumnName("IsTrained");
                    p.Property(p => p.HasFears).HasColumnName("HasFears");
                    p.Property(p => p.FearsDescription).HasColumnName("FearsDescription");
                });
        
        builder
            .OwnsOne(p => p.HealthStatus, 
                hs =>
                {
                    hs.Property(hs => hs.IsVaccinated).HasColumnName("IsVaccinated");
                    hs.Property(hs => hs.IsCastrated).HasColumnName("IsCastrated");
                    hs.Property(hs => hs.TakesMedications).HasColumnName("TakesMedications");
                    hs.Property(hs => hs.HasEatingSchedule).HasColumnName("HasEatingSchedule");
                    hs.Property(hs => hs.OtherDietaryNeeds).HasColumnName("OtherDietaryNeeds");
                    hs.Property(hs => hs.HealthProblems).HasColumnName("HealthProblems");
                });
    }
}