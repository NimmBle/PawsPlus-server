namespace Zoolandia.Application.Common;

public class EntityCommand<TId>
{
    public TId Id { get; set; } = default!;
}