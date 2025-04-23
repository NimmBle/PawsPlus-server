using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Features.Reviews;
using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class ReviewRepository(PawsPlusDbContext db, IMapper mapper) 
    : DataRepository<PawsPlusDbContext, Review>(db),
        IReviewDomainRepository,
        IReviewQueryRepository
{
    public async Task<bool> Delete(string Id, CancellationToken cancellationToken = default)
    { 
        var review = db.Reviews.Find(Id);
        
        this.Data.Reviews.Remove(review);
        
        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<ICollection<ReviewOutputModel>> GetByReviewedId(string id,
        CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<ReviewOutputModel>(this
                .All()
                .Where(r => r.Reviewed.Id == id)
                .Include(r => r.Reviewer))
            .ToListAsync();
}