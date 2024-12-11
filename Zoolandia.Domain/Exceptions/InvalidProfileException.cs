using Zoolandia.Domain.Common;

namespace Zoolandia.Domain.Exceptions;

public class InvalidProfileException : BaseDomainException
{
    public InvalidProfileException()
    {
    }

    public InvalidProfileException(string errorMessage) => this.Error = errorMessage;
}