using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class ReviewErrors
{
    public static Error ReviewCreationNotAllowed() => Error.Forbidden(
        "Review.ReviewCreationNotAllowed", $"Не ви е позволено да напишете отзив за гледач, преди да сте използвали неговите услуги");

    public static Error ReviewAlreadyExists() => Error.Conflict(
        "Review.ReviewAlreadyExists", $"Вече сте написали отзив за услугите на този гледач");

}