using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsPlus.Domain.Models;

namespace PawsPlus.Infrastructure.Configuration;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .HasKey(p => p.Id);
        
        builder
            .HasMany(p => p.Services)
            .WithOne(s => s.Post)
            .HasForeignKey(s => s.PostId);
        
        builder
            .OwnsOne(p => p.Status,
                s =>
                {
                    s.WithOwner();

                    s.Property(s => s.Value);
                });

        builder
            .HasMany(p => p.Animals)
            .WithMany(p => p.Posts);
    }
}