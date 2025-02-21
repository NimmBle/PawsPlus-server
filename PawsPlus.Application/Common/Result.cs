using PawsPlus.Domain.Common;

namespace PawsPlus.Application.Common;

public class Result
{

    internal Result(bool succeeded, Error error)
    {
        this.Succeeded = succeeded;
        this.Error = error;
    }
    public bool Succeeded { get; private set; }
    
    public Error Error { get; private set; }
    
    public static Result Success
        => new Result(true, Error.None);

    public static Result Failure(Error error)
        => new Result(false, error);

    public static implicit operator Result(Error error)
        => Failure(error);

    public static implicit operator Result(bool success)
        => Success;
}

public class Result<TData> : Result
{
    private readonly TData _data;

    private Result(bool succeeded, TData data, Error error)
        : base(succeeded, error)
        => this._data = data;

    public TData Data
        => this.Succeeded
            ? this._data
            : throw new InvalidOperationException(
                $"{nameof(this.Data)} is unavailable with a failed result. Use {this.Error} instead. ");
    
    public static Result<TData> SuccessWith(TData data)
        => new(true, data, Error.None);
    
    public static Result<TData> Failure(Error error)
        => new(false, default!, error);
    
    public static implicit operator Result<TData>(Error error)
        => Failure(error);

    public static implicit operator Result<TData>(TData data)
        => SuccessWith(data);

}