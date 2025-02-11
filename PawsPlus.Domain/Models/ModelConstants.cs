namespace PawsPlus.Domain.Models;

public class ModelConstants
{

    public class Common
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 20;
        
        public const int MinEmailLength = 6;
        public const int MaxEmailLength = 50;
        
        public const int MaxUrlLength = 2048;
        
        public const int Zero = 0;
    }
    
    public class Profile
    {
        public const int MaxDescriptionLength = 1024;
    }
    
    public class Pet
    {
        public const int MaxDescriptionLength = 1024;
    }
    
    public class JobPost
    {
        public const int MaxDescriptionLength = 1024;
    }
}