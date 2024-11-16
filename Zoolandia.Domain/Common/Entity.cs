namespace Zoolandia.Domain.Common;

public class Entity<TId>
{
    public TId Id { get; set; } = default!;
}