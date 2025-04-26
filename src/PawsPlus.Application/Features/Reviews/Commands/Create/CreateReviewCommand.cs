using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Features.Booking;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Reviews.Commands.Create;

public class CreateReviewCommand : IRequest<Result>
{
    public double Rating { get; set; }
    
    public string Content { get; set; }
    
    public string ReviewerId { get; set; }
    
    public string ReviewedId { get; set; }
    
    public class CreateReviewCommandHandler(IReviewDomainRepository reviewDomainRepository,
        IReviewQueryRepository reviewQueryRepository,
        IBookingQueryRepository bookingQueryRepository) 
        : IRequestHandler<CreateReviewCommand, Result>
    { 
        public async Task<Result> Handle(CreateReviewCommand request,
            CancellationToken cancellationToken)
        {
            // var completedBookings = await bookingQueryRepository.GetCompletedBookingsByProfileIds(request.ReviewerId, request.ReviewedId);
            // if (completedBookings == 0)
            // {
            //     return ReviewErrors.ReviewCreationNotAllowed();
            // }
            //
            // var existingReview = await reviewQueryRepository.ReviewExistsByReviewerAndReviewedId(request.ReviewerId, request.ReviewedId);
            // if (existingReview)
            // {
            //     return ReviewErrors.ReviewAlreadyExists();
            // }
            
            var review = new Review(request.Rating,
                request.Content,
                request.ReviewerId,
                request.ReviewedId);

            await reviewDomainRepository.Save(review, cancellationToken);

            return Result.Success;
        }
    }
}