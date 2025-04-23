using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsPlus.Domain.Models;

namespace PawsPlus.Infrastructure.Configuration;

public class ServiceConfirguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder
            .HasKey(s => s.Id);
        
        builder
            .HasMany(s => s.MeetingPlaces)
            .WithMany(m => m.Services);
        
        builder
            .HasMany(s => s.AvailableDates)
            .WithMany(s => s.Services);
    }
}