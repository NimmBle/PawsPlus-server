using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawsPlus.Domain.Models;

namespace PawsPlus.Infrastructure.Configuration;

public class ServiceConfirguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
  
    }
}