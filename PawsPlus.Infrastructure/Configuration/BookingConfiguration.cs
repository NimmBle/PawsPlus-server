using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsPlus.Domain.Models;

namespace PawsPlus.Infrastructure.Configuration;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder
            .HasKey(b => b.Id);
        
        builder
            .Property(b => b.FromTime)
            .HasConversion(
                to => to.ToString("HH:mm"),
                from => TimeOnly.ParseExact(from, "HH:mm")
            );
        
        builder
            .Property(b => b.ToTime)
            .HasConversion(
                to => to.ToString("HH:mm"),
                from => TimeOnly.ParseExact(from, "HH:mm")
            );
        
        builder
            .HasOne(b => b.Sitter)
            .WithMany(p => p.BookingsAsSitter)
            .HasForeignKey(b => b.SitterId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(b => b.Owner)
            .WithMany(p => p.BookingsAsOwner)
            .HasForeignKey(b => b.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(b => b.Service)
            .WithMany(s => s.Bookings)
            .HasForeignKey(b => b.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .OwnsOne(p => p.RequestStatus,
                s =>
                {
                    s.WithOwner();

                    s.Property(s => s.Value);
                });
    }
}