using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class PostErrors
{
    public static Error PostsNotFound() => Error.NotFound(
        "Post.PostsNotFound", $"Няма намерени публикации с тези критерии за търсене.");

    public static Error PostNotFound(string id) => Error.NotFound(
        "Post.PostNotFound", $"Няма намерена публикация с този идентификатор: {id}.");

    public static Error PostAlreadyResolved => Error.Conflict(
        "Post.PostAlreadyResolved", $"Тази публикация вече е обработена.");

    public static Error PostAnimalTypeNotFound => Error.Conflict(
        "Post.PostAnimalTypeNotFound", $"Тази публикация не съдържа типа животно, който сте поискали.");
}