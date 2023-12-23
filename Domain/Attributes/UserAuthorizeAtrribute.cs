using Shared.Enum;

namespace Domain.Attributes;

public class UserAuthorizeAtrribute:CheckTokenInRedisAttribute
{
    
    public UserAuthorizeAtrribute() {

        AuthenticationSchemes = JwtSchema.User.ToString();
    }
}