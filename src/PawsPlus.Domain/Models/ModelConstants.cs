namespace PawsPlus.Domain.Models;

public class ModelConstants
{

    public class Common
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 20;
        
        public const int MinEmailLength = 6;
        public const int MaxEmailLength = 50;
        
        public const int MaxUrlLength = 1024;
        
        public const int Zero = 0;
    }
    
    public class Profile
    {
        public const int MaxDescriptionLength = 1024;
        
        public const int MinPhoneNumberLength = 7;
        public const int MaxPhoneNumberLength = 10;
    }
    
    public class Pet
    {
        public const int MaxGenderLength = 10;
        public const int MaxNameLength = 20;
        public const int MaxDescriptionLength = 1024;
    }
    
    public class Booking
    {
        public const int MaxDescriptionLength = 1024;
    }

    public class Review
    {
        public const int MinRatingValue = 1;
        public const int MaxRatingValue = 5;

        public const int MinContentLength = 2;
        public const int MaxContentLength = 1024;
    }
}