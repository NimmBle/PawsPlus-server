namespace Zoolandia.Server.Infrastructure.Services;

public class Result
{
    public bool Succeeded { get; private set; }

    public bool Failure => !Succeeded;
    
    public string Error { get; private set; }


    public static implicit operator Result(string error)
        => new Result()
        {
            Succeeded = false,
            Error = error
        };

    public static implicit operator Result(bool succeeded)
        => new Result() { Succeeded = succeeded };
}