using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsPlus.Domain.Models;

namespace PawsPlus.Infrastructure.Configuration;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder
            .HasKey(r => r.Id);

        builder
            .HasOne(r => r.Reviewer)
            .WithMany(p => p.GivenReviews)
            .HasForeignKey(r => r.ReviewerId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder
            .HasOne(r => r.Reviewed)
            .WithMany(p => p.ReceivedReviews)
            .HasForeignKey(r => r.ReviewedId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}