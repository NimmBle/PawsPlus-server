using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class FileErrors
{
    public static Error FileLengthInvalid => Error.Validation(
        "File.FileLengthInvalid", $"The length of the file is invalid. Please try again, or with a different file."); 
}