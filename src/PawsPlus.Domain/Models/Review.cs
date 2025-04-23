using PawsPlus.Domain.Common;
using PawsPlus.Domain.Common.Models;
using PawsPlus.Domain.Exceptions;
using static PawsPlus.Domain.Models.ModelConstants.Review;

namespace PawsPlus.Domain.Models;

public class Review : IAggregateRoot
{
    private Review()
    {
    }
    
    public Review(double rating,
        string content,
        string reviewerId,
        string reviewedId)
    {
        this.ValidateRating(rating);
        this.ValidateContent(content);
        
        this.Id = Guid.NewGuid().ToString();
        this.Rating = rating;
        this.Content = content;
        this.ReviewerId = reviewerId;
        this.ReviewedId = reviewedId;
        this.ReviewDate = DateOnly.FromDateTime(DateTime.Now);
    }
    
    public string Id { get; set; }
    
    public double Rating { get; private set; }
    
    public string Content { get; private set; }
    
    public Profile Reviewer { get; private set; }
    
    public string ReviewerId { get; private set; }
    
    public Profile Reviewed { get; private set; }
    
    public string ReviewedId { get; private set; }
    
    public DateOnly ReviewDate { get; private set; }
    
    
    private void ValidateRating(double rating)
        => Guard.ForDoubleValue<InvalidReviewException>(
            rating,
            MinRatingValue,
            MaxRatingValue,
            nameof(Rating));
    
    private void ValidateContent(string content)
        => Guard.ForStringLength<InvalidReviewException>(
            content,
            MinContentLength,
            MaxContentLength,
            nameof(Content));
}