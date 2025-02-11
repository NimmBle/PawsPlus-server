using PawsPlus.Domain.Models;

namespace PawsPlus.Application.Identity;

public interface IUser
{
    void CreateProfile(Profile profile);
}