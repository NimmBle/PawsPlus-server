using System.Text.Json.Serialization;
using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Models;

public class Date : IAggregateRoot 
{
    public Date(DateOnly day)
    {
        this.Day = day;
    }
    
    public DateOnly Day { get; private set; }
    
    [JsonIgnore]
    public List<Service> Services { get; set; } = new();
}