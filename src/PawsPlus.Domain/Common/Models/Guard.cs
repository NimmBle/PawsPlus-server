using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Common.Models;

public static class Guard
{
    public static void ForValidUrl<TException>(string url, string name = "Value")
        where TException : BaseDomainException, new()
    {
        if (url.Length <= ModelConstants.Common.MaxUrlLength &&
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

    public static void ForDoubleValue<TException>(double value, int minValue, int maxValue, string name = "Value")
        where TException : BaseDomainException, new()
    {
        if (value >= minValue && value <= maxValue)
        {
            return;
        }
        ThrowException<TException>($"{name} must be between {minValue} and {maxValue}");
    }

    public static void ForNegativeNumber<TException>(int value, string name = "Value")
        where TException : BaseDomainException, new()
    {
        if (value >= 0)
        {
            return;
        }
        ThrowException<TException>($"{name} must be a positive number");
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