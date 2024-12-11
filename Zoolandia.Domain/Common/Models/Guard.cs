using static Zoolandia.Domain.Models.ModelConstants.Common;

namespace Zoolandia.Domain.Common.Models;

public static class Guard
{
    public static void ForValidUrl<TException>(string url, string name = "Value")
        where TException : BaseDomainException, new()
    {
        if (url.Length >= MaxUrlLength &&
            Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            return;
        }
        ThrowException<TException>($"{name} must be a valid URL");
            
    }
    
    public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
        where TException : BaseDomainException, new()
    {
        if (value.Length >= minLength && value.Length <= maxLength)
        {
            return;
        }
        ThrowException<TException>($"{name} must be between {minLength} and {maxLength}");
    }

    public static void ThrowException<TException>(string errorMessage)
        where TException : BaseDomainException, new()
    {
        var exception = new TException
        {
            Error = errorMessage
        };

        throw exception;
    }
}