using Zoolandia.Domain.Models;

namespace Zoolandia.Application.Identity;

public interface IUser
{
    void CreateProfile(Profile profile);
}