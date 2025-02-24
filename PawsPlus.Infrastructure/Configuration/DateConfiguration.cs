using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsPlus.Domain.Models;

namespace PawsPlus.Infrastructure.Configuration;

public class DateConfiguration : IEntityTypeConfiguration<Date>
{
    public void Configure(EntityTypeBuilder<Date> builder)
    {

        builder
            .HasKey(p => p.Day);
        
    }
}