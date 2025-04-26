namespace PawsPlus.Application.Features.Reviews;

public interface IReviewQueryRepository
{
    Task<ICollection<ReviewOutputModel>> GetByReviewedId(string id, CancellationToken cancellationToken = default);
    
    Task<bool> ReviewExistsByReviewerAndReviewedId(string reviewerId, string reviewedId, CancellationToken cancellationToken = default);
}