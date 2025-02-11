namespace PawsPlus.Domain.Common;

public class Entity<TId>
{
    public TId Id { get; set; } = default!;
}