using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Exceptions;

public class InvalidProfileException : BaseDomainException
{
    public InvalidProfileException()
    {
    }

    public InvalidProfileException(string errorMessage) => this.Error = errorMessage;
}