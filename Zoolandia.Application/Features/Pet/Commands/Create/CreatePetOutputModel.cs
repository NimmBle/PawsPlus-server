namespace Zoolandia.Application.Features.Pet.Commands.Create;

public class CreatePetOutputModel
{
    public CreatePetOutputModel(string id)
    {
        this.Id = id;
    }
    public string Id { get; set; }
}