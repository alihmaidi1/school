using Common.Entity.Interface;
using Shared.Enum;

namespace Repository.Jwt.Factory;

public interface ISchemaFactory:basesuper
{

    public IJwtRepository CreateJwt(JwtSchema Schema);

    
}