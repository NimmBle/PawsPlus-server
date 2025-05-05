using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Features.Profile;
using PawsPlus.Application.Features.Profile.Queries;
using PawsPlus.Application.Features.Profile.Queries.Mine;
using PawsPlus.Application.Features.Profile.Queries.Details;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;
using Profile = PawsPlus.Domain.Models.Profile;

namespace PawsPlus.Infrastructure.Repositories;

public class ProfileRepository(PawsPlusDbContext db,
    IMapper mapper)
    : DataRepository<PawsPlusDbContext, Profile>(db),
        IProfileDomainRepository,
        IProfileQueryRepository
{
    public async Task<Profile> Find(string profileId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(p => p.Id == profileId)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<Profile?> FindByUser(string userId,
        CancellationToken cancellationToken = default)
        => await this
            .Data
            .Users
            .Where(u => u.Id == userId)
            .Select(u => u.Profile)
            .FirstOrDefaultAsync(cancellationToken);
    
    public async Task<ProfileDetailsOutputModel?> GetDetails(string profileId,
        CancellationToken cancellationToken = default)
        => await this
                .All()
                .Where(p => p.Id == profileId)
                .Select(p => new ProfileDetailsOutputModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    PhoneNumber = p.PhoneNumber,
                    Description = p.Description,
                    PhotoUrl = p.PhotoUrl ?? "https://res.cloudinary.com/ds95qikmm/image/upload/v1732147641/happy-man-sitting-with-three-cats-armchair-cartoon 1.svg.svg",
                    Location = new LocationOutputModel
                    {
                        PlaceId = p.Location.PlaceId,
                    }
                })
                .FirstOrDefaultAsync(cancellationToken);

        

    public async Task<MineProfileOutputModel> GetMine(string id,
        CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<MineProfileOutputModel>(this
                .All()
                .Where(p => p.Id == id)
                .Include(p => p.Location))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<ProfilePetLocationDto> GetPetLocation(string userId,
        CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<ProfilePetLocationDto>(this
                .Data
                .Users
                .Where(u => u.Id == userId)
                .Select(u => u.Profile))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<ProfileEmailInformationDto> GetEmailInformation(string id,
        CancellationToken cancellationToken = default)
        => await this
            .Data
            .Users
            .Where(u => u.Profile.Id == id)
            .Select(u => new ProfileEmailInformationDto(u.Email,
                u.Profile.FirstName,
                u.Profile.LastName))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<string> GetProfileIdByUser(string userId,
        CancellationToken cancellationToken = default)
        => await this
            .Data
            .Users
            .Where(u => u.Id == userId)
            .Select(u => u.Profile.Id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<string> GetUserIdByProfileId(string profileId,
        CancellationToken cancellationToken = default)
        => await this
            .Data
            .Users
            .Where(u => u.Profile.Id == profileId)
            .Select(u => u.Id)
            .FirstOrDefaultAsync(cancellationToken);
}