using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace PawsPlus.Server;

public class FirebaseInitializer
{
    private static readonly object _lock = new object();

    public static void EnsureInitialized()
    {
        if (FirebaseApp.GetInstance("[DEFAULT]") == null)
        {
            lock (_lock)
            {
                if (FirebaseApp.GetInstance("[DEFAULT]") == null)
                {
                    FirebaseApp.Create(new AppOptions
                    {
                        Credential = GoogleCredential.FromFile("./firebase-adminsdk.json")
                    });
                }
            }
        }
    }
}