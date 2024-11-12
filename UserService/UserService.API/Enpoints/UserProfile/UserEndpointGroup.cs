using UserService.API.Common;

namespace UserService.API.Enpoints.User
{
    public class UserProfileEndpointGroup : EndpointGroupBase
    {
        public UserProfileEndpointGroup() : base("UserProfile", "userProfile")
        {
        }
    }
}
