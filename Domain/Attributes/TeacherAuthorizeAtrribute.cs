using Shared.Enum;

namespace Domain.Attributes;

public class TeacherAuthorizeAtrribute:CheckTokenInRedisAttribute
{
    
    
    public TeacherAuthorizeAtrribute() {

        AuthenticationSchemes = JwtSchema.Teacher.ToString();
    }
    
}