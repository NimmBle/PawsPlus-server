using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zoolandia.Domain.Models;

namespace Zoolandia.Infrastructure.Configuration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder
            .ComplexProperty(
                p => p.Age,
                a =>
                {
                    a.Property(a => a.Years).HasColumnName("YearsOld");
                    a.Property(a => a.Months).HasColumnName("MonthsOld");
                });
        
        builder
            .ComplexProperty(p => p.Personality,
                p =>
                {
                    p.Property(p => p.Temperament).HasColumnName("Temperament");
                    p.Property(p => p.ActivityLevel).HasColumnName("ActivityLevel");
                    p.Property(p => p.IsTrained).HasColumnName("IsTrained");
                    p.Property(p => p.HasFears).HasColumnName("HasFears");
                    p.Property(p => p.FearsDescription).HasColumnName("FearsDescription");
                });
        
        builder
            .ComplexProperty(p => p.HealthStatus, 
                hs =>
                {
                    hs.Property(hs => hs.IsVaccinated).HasColumnName("IsVaccinated");
                });
    }
}