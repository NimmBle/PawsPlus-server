using PawsPlus.Domain.Common;
using PawsPlus.Domain.Enums;

namespace PawsPlus.Domain.Models;

public class Service : Entity<string>, IAggregateRoot
{
    private Service()
    {
    }
    
    internal Service(ServiceType serviceType)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Name = serviceType.ToString();
    }

    public Service(ServiceType serviceType,
        int price,
        List<DateOnly>? availableDates,
        string postId)
        : this(serviceType)
    {
        this.Price = price;
        this.AvailableDates = availableDates;
        this.PostId = postId;
    }

    public string Name { get; private set; }

    public int Price { get; private set; } = 0;

    public List<DateOnly>? AvailableDates { get; private set; } = new List<DateOnly>();
    
    public string PostId { get; private set; }
    public Post Post { get; private set; }

    public void UpdatePrice(int newPrice)
    {
        Price = newPrice;
    }

    public void UpdateAvailableDates(List<DateOnly> newAvailableDates)
    {
        var yesterday = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));
        
        newAvailableDates.RemoveAll(date => date <= yesterday);
        
        AvailableDates = newAvailableDates; 
    }
}