using NetTopologySuite.Geometries;

namespace Zoolandia.Domain.ValueObjects;

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
    
    public string? PlaceId { get; init; }
    
    public Point? Point { get; init; }

    public double GetDistanceInKilometers(double latitude, double longitude)
    {
        if ( Point == null )
            return double.NaN;
        
        var newPoint = new Point(latitude, longitude) { SRID = 4326 };
        
        var distance = this.Point.Distance(newPoint) * 100;
        
        return distance;
    }
    
}