using Bogus;
using PawsPlus.Domain.Exceptions;
using PawsPlus.Domain.Models;
using Shouldly;

namespace Domain.UnitTests;

public class ReviewTests
{
    private readonly Faker _faker = new();

    [Theory]
    [InlineData(-2)]
    [InlineData(0)]
    [InlineData(6)]
    [InlineData(12)]
    public void CreateReview_Should_ThrowException_WhenRatingIsLessThanOneAndMoreThanFive(double rating)
    {
        Should.Throw<InvalidReviewException>(() => new Review(rating,
            _faker.Lorem.Sentence(10),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString()));
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(1200)]
    [InlineData(0)]
    public void CreateReview_Should_ThrowException_WhenContentIsLessThanTwoAndMoreThanAThousandCharacters(int contentLength)
    {
        Should.Throw<InvalidReviewException>(() => new Review(1,
            _faker.Random.String(contentLength),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString()));
    }
    
    [Fact]
    public void CreateReview_Should_ThrowException_WhenReviewerIdAndReviewedIdsAreTheSame()
    {
        var id = Guid.NewGuid().ToString();
        Should.Throw<InvalidReviewException>(() => new Review(1,
            _faker.Lorem.Sentence(10),
            id,
            id));
    }
    
    [Fact]
    public void CreateReview_Should_Create_WhenAllDataIsValid()
    {
        var rating = _faker.Random.Int(1, 5);
        var content = _faker.Lorem.Sentence(10);
        var reviewerId = _faker.Random.String(10);
        var reviewedId = _faker.Random.String(10);
        
        var review = new Review(rating,
            content,
            reviewerId,
            reviewedId
            );
        review.ShouldNotBeNull();
        review.Rating.ShouldBe(rating);
        review.Content.ShouldBe(content);
        review.ReviewerId.ShouldBe(reviewerId);
        review.ReviewedId.ShouldBe(reviewedId);

    }
}