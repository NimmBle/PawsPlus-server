using Microsoft.EntityFrameworkCore;

namespace PawsPlus.Infrastructure.Common.Persistence;

internal class DatabaseInitializer(PawsPlusDbContext db)
    : IInitializer
{
    public void Initialize()
    {
        db.Database.Migrate();
    }
}