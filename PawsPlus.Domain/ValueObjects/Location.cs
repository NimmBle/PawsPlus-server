using NetTopologySuite.Geometries;

namespace PawsPlus.Domain.ValueObjects;

public record Location
{
    private Location()
    {
    }
        
    public Location(string placeId,
        double latitude,
        double longitude)
    {
        this.PlaceId = placeId;
        this.Point = new Point(latitude, longitude) { SRID = 4326 };
    }
    
    public string? PlaceId { get; }
    
    public Point? Point { get; }
    
}