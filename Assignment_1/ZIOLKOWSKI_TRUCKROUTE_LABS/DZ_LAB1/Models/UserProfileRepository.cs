using Microsoft.AspNetCore.Identity;

namespace DZ_LAB1.Models
{
    public class UserProfileRepository

    {
        public static List<UserProfile> _UserProfiles= new List<UserProfile>();

        public static void AddUserProfile(UserProfile userProfile)
        {
            _UserProfiles.Add(userProfile);
        }

        public static void GetUserProfile(UserProfile userProfile)
        {

        }

    }
}
