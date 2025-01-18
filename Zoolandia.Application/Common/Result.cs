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
    private readonly TData _data;

    private Result(bool succeeded, TData data, List<string> error)
        : base(succeeded, error)
        => this._data = data;

    public TData Data
        => this.Succeeded
            ? this._data
            : throw new InvalidOperationException(
                $"{nameof(this.Data)} is unavailable with a failed result. Use {this.Errors} instead. ");
    
    public static Result<TData> SuccessWith(TData data)
        => new(true, data, new List<string>());
    
    public static Result<TData> Failure(string error)
        => Failure(new List<string> { error });
    
    public static Result<TData> Failure(IEnumerable<string> errors)
        => new(false, default!, errors.ToList());
    
    public static implicit operator Result<TData>(string error)
        => Failure(new List<string> { error });

    public static implicit operator Result<TData>(List<string> errors)
        => Failure(errors);

    public static implicit operator Result<TData>(TData data)
        => SuccessWith(data);

}