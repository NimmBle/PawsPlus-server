using System.Text.Json.Serialization;
using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Models;

public class MeetingPlace : Entity<int>, IAggregateRoot
{
    public MeetingPlace(int id,string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public string Name { get; private set; }
    
    public List<Booking> Bookings { get; private set; } = new List<Booking>();
    
    [JsonIgnore]
    public List<Service> Services { get; private set; } = new List<Service>();
}