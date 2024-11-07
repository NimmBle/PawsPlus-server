namespace Zoolandia.Application.Common;

public class Result
{

    internal Result(bool succeeded, List<string> errors)
    {
        this.Succeeded = succeeded;
        this.Errors = errors;
    }
    public bool Succeeded { get; private set; }
    
    public List<string> Errors { get; private set; }
    
    
    public static Result Success
        => new Result(true, new List<string>());

    public static Result Failure(IEnumerable<string> errors)
        => new Result(false, errors.ToList());
    


    public static implicit operator Result(string error)
        => Failure(new List<string>() { error });

    public static implicit operator Result(bool success)
        => success ? Success : Failure(new[] { "Unsuccessful operation " });
}

public class Result<TData> : Result
{
    private readonly TData data;

    private Result(bool succeeded, TData data, List<string> error)
        : base(succeeded, error)
        => this.data = data;
    
    public static Result<TData> SuccessWith(TData data)
        => new(true, data, new List<string>());

    public static Result<TData> Failure(IEnumerable<string> errors)
        => new(false, default!, errors.ToList());

}