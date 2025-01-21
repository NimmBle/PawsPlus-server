using Zoolandia.Domain.Common;
using Zoolandia.Domain.Enums;

namespace Zoolandia.Domain.Models;

public class Service : Entity<string>, IAggregateRoot
{
    public Service(ServiceType serviceType)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Name = serviceType.ToString();
    }

    public Service(ServiceType serviceType,
        int price,
        HashSet<DateOnly> availableDates,
        string postId)
        : this(serviceType)
    {
        this.Price = price;
        this.AvailableDates = availableDates;
        this.PostId = postId;
    }

    public string Name { get; private set; }

    public int Price { get; private set; } = 0;

    public HashSet<DateOnly>? AvailableDates { get; private set; } = new HashSet<DateOnly>();
    
    public string PostId { get; private set; }
    public Post Post { get; private set; }

    public void UpdatePrice(int newPrice)
    {
        Price = newPrice;
    }

    public void UpdateAvailableDates(HashSet<DateOnly> newAvailableDates)
    {
        AvailableDates = newAvailableDates;
    }
}