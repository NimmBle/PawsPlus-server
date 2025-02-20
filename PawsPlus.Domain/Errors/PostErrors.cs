using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class PostErrors
{
    public static Error PostsNotFound() => Error.NotFound(
        "Post.PostsNotFound", $"No posts were found with this searching criteria.");
    
    public static Error PostNotFound(string id) => Error.NotFound(
        "Post.PostNotFound", $"No post was found with this id: {id}.");
    
    public static Error PostAlreadyResolved => Error.Conflict(
        "Post.PostAlreadyResolved", $"This post has already been resolved");
    
    public static Error PostAnimalTypeNotFound => Error.Conflict(
        "Post.PostAnimalTypeNotFound", $"This post does not contains the animal type you have requested");

}