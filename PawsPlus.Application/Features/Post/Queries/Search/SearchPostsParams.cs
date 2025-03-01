using System.Linq.Expressions;
using NetTopologySuite.Geometries;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Models;

namespace PawsPlus.Application.Features.Post.Queries.Search;

public class SearchPostsParams
{
    public int PetType { get; set; }
    
    public ServiceType ServiceType { get; set; }
    
    public double? Latitude { get; set; }
    
    public double? Longitude { get; set; }
    
    public string? StartDate { get; set; }
    
    public string? EndDate { get; set; }
    
    public int? MinPrice { get; set; }
    
    public int? MaxPrice { get; set; }

    public int PostsPerPage { get; set; } = 10;
    
    public int Page { get; set; } = 1;
    
    
    public Expression<Func<Domain.Models.Post, bool>> ToPredicate()
    {
        Expression<Func<Domain.Models.Post, bool>> predicate = x => true;

        predicate = predicate.And(p => p.Status.Value == PostState.Approved.Value);
        
        // PetType
        if (PetType != 0)
        {
            predicate = predicate.And(p => p.Animals
                .Any(at => at.Id == PetType));
        }
        
        // ServiceType
        if (!string.IsNullOrWhiteSpace(ServiceType.ToString()))
        {
            predicate = predicate.And(p => p.Services
                .Any(s => s.Name == ServiceType.ToString()));
        }
        
        // Location
        if (Latitude != 0 && Latitude != null &&
            Longitude != 0 && Longitude != null)
        {
            double radiusInKilometers = 25.0;
            
            var centerPoint = new Point(Latitude.Value, Longitude.Value) { SRID = 4326 };
        
            predicate = predicate.And(p => p.Profile.Location.Point.Distance(centerPoint) * 100 < radiusInKilometers);
        }
        
        // StartDate and EndDate
        if (StartDate is not null && EndDate is not null)
        {
            var startDate = DateOnly.Parse(StartDate);
            var endDate = DateOnly.Parse(EndDate);
            
            var totalDays = endDate.DayNumber - startDate.DayNumber + 1;
            
            var dateRange = Enumerable.Range(0, totalDays)
                .Select(offset => startDate.AddDays(offset));

            predicate = predicate.And(p => p.Services
                .Where(s => ServiceType.ToString() == s.Name)
                .Any(s => dateRange
                .All(rd => s.AvailableDates
                .Any(d => d.Day.Equals(rd)))));
        }
        else if (StartDate is not null && EndDate is null)
        {
            predicate = predicate.And(p => p.Services
                .Where(s => ServiceType.ToString() == s.Name)
                .Any(s => s.AvailableDates
                .Any(d => d.Day.Equals(DateOnly.Parse(StartDate)))));
        }
        else if (StartDate is null && EndDate is not null)
        {
            predicate = predicate.And(p => p.Services
                .Where(s => ServiceType.ToString() == s.Name)
                .Any(s => s.AvailableDates
                .Any(d => d.Day.Equals(DateOnly.Parse(EndDate)))));
        }

        // MIN AND MAX PRICE
        if (MinPrice is not null && MinPrice < MaxPrice)
        {
            predicate = predicate.And(p => p.Services
                .Where(s => s.Price >= MinPrice)
                .Any());
        }

        if (MaxPrice is not null && MaxPrice > MinPrice)
        {
            predicate = predicate.And(p => p.Services
                .Where(s => s.Price <= MaxPrice)
                .Any());
        }

        return predicate;
    }

    public Expression<Func<Domain.Models.Post, object>> OrderBy()
    {
        Expression<Func<Domain.Models.Post, object>> orderBy;

        if (Latitude != 0 && Latitude != null &&
            Longitude != 0 && Longitude != null)
        {
            var centerPoint = new Point(Latitude.Value, Longitude.Value) { SRID = 4326 };
            orderBy = p =>
                p.Profile.Location.Point.Distance(centerPoint);
        }
        else
        {
            orderBy = p => p.Id;
        }

        return orderBy;
    }
}