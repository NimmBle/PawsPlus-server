using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class ReviewErrors
{
    public static Error ReviewCreationNotAllowed() => Error.Forbidden(
        "Review.ReviewCreationNotAllowed", $"You are not allowed to review a sitter before using their services");

    public static Error ReviewAlreadyExists() => Error.Conflict(
        "Review.ReviewAlreadyExists", $"You have already written a review about this sitters' services");

}