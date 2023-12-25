using Shared.Enum;

namespace Repository.Jwt.Factory;

public interface ISchemaFactory
{

    public IJwtRepository CreateJwt(JwtSchema Schema);

    
}