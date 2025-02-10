using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.VisualBasic.CompilerServices;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Application.Features.Post.Queries.Search;

public class SearchPostsParams
{
    public PetType PetType { get; set; }
    
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

        // PetType
        if (!string.IsNullOrWhiteSpace(PetType.ToString()))
        {
            predicate = predicate.And(p => p.PetTypes
                .Select(t => t)
                .Contains(PetType));
        }
        
        // ServiceType
        if (!string.IsNullOrWhiteSpace(ServiceType.ToString()))
        {
            predicate = predicate.And(p => p.Services
                .Where(s => s.Name == ServiceType.ToString())
                .Any());
        }
        
        // Location
        if (Latitude != 0 && Latitude != null &&
            Longitude != 0 && Longitude != null)
        {
            predicate = predicate.And(p => p.Profile
                .Location.GetDistanceInKilometers(Latitude.Value, Longitude.Value) <= 1.5);
        }
        
        // StardDate and EndDate
        if (StartDate is not null && EndDate is not null)
        {
            predicate = predicate.And(p => p.Services
                .Select(s => s.AvailableDates)
                .Where(ad => ad.Contains(DateOnly.Parse(StartDate)))
                .Any());
            
            predicate = predicate.And(p => p.Services
                .Select(s => s.AvailableDates)
                .Where(ad => ad.Contains(DateOnly.Parse(StartDate)))
                .Any());
        }
        else if (StartDate is not null && EndDate is null)
        {
            predicate = predicate.And(p => p.Services
                .Select(s => s.AvailableDates)
                .Where(ad => ad.Contains(DateOnly.Parse(StartDate)))
                .Any());
        }
        else if (StartDate is null && EndDate is not null)
        {
            predicate = predicate.And(p => p.Services
                .Select(s => s.AvailableDates)
                .Where(ad => ad.Contains(DateOnly.Parse(EndDate)))
                .Any());
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
}