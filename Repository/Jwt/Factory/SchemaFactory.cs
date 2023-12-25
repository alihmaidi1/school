
using Microsoft.Extensions.Configuration;
using Domain.Enum;
using infrutructure;
using Shared.Enum;
using Shared.Jwt;
using Shared.Redis;

namespace Repository.Jwt.Factory;

public class SchemaFactory:ISchemaFactory
{
    
    
    public ApplicationDbContext DbContext { get; set; }

    public ICacheRepository CacheRepository;

    public IConfiguration configration { get; set; }

    public SchemaFactory(IConfiguration configration,ApplicationDbContext DbContext,ICacheRepository CacheRepository)
    {

        this.configration = configration;

        this.CacheRepository = CacheRepository;
        this.DbContext = DbContext;

    }
    
    public IJwtRepository CreateJwt(JwtSchema Schema)
    {
        var Setting=configration.GetSection(Schema.ToString()).Get<JwtSetting>();
        return new JwtRepository(Setting, DbContext, CacheRepository);

    }
}