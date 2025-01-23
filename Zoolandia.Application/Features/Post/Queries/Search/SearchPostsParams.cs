using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Microsoft.VisualBasic.CompilerServices;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Application.Features.Post.Queries.Search;

public class SearchPostsParams
{
    public PetType PetType { get; set; }
    
    public ServiceType ServiceType { get; set; }
    
    public string? StartDate { get; set; }
    
    public string? EndDate { get; set; }

    public int PostsPerPage { get; set; } = 10;
    
    public int Page { get; set; } = 1;
    
    public string? Location { get; set; }
    
    
    public Expression<Func<Domain.Models.Post, bool>> ToPredicate()
    {
        Expression<Func<Domain.Models.Post, bool>> predicate = x => true;

        if (!string.IsNullOrWhiteSpace(PetType.ToString()))
        {
            predicate = predicate.And(p => p.PetTypes
                .Select(t => t)
                .Contains(PetType));
        }
        
        if (!string.IsNullOrWhiteSpace(ServiceType.ToString()))
        {
            predicate = predicate.And(p => p.Services
                .Where(s => s.Name == ServiceType.ToString())
                .Any());
        }

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

        return predicate;
    }
}