
using Shared.Enum;

namespace Domain.Attributes;

public class StudentAuthorizeAtrribute:CheckTokenInRedisAttribute
{
    
    public StudentAuthorizeAtrribute() {

        AuthenticationSchemes = JwtSchema.Student.ToString();
    }
}