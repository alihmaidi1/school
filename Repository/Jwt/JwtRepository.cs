using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Domain.Base.Entity;
using infrutructure;
using Microsoft.IdentityModel.Tokens;
using Shared.Jwt;
using Shared.Redis;

namespace Repository.Jwt;

public class JwtRepository:IJwtRepository
{
    public readonly JwtSetting JwtOption;
    public readonly ApplicationDbContext Context; 

    public readonly ICacheRepository CacheRepository;

    public JwtRepository(JwtSetting Setting, ApplicationDbContext DbContext, ICacheRepository cacheRepository)
    {

        this.Context = DbContext;
        this.CacheRepository = cacheRepository;
        this.JwtOption = Setting;

    }
    
    public  async Task<(RefreshToken refreshToken,string token,int ExpiredAt)> GetTokensInfo(Guid Id,string Email)  
    {
        
        
        string Token = GetToken(Id,Email);
        RefreshToken RefreshToken = GenerateRefreshToken();
        return (RefreshToken, Token,(int )JwtOption.DurationInMinute * 60);

    }

    
    
    
    
    public string GetToken(Guid Id,string Email)
    {
        var claims = CreateClaim(Id,Email);
        var signingCredentials = GetSigningCredentials(JwtOption);
        var JwtToken = GetJwtToken(JwtOption, claims, signingCredentials);
        var Token = new JwtSecurityTokenHandler().WriteToken(JwtToken);
        var ExpiredAt = DateTimeOffset.Now.AddMinutes(JwtOption.DurationInMinute);
        this.CacheRepository.SetData("Token:" + Token, Token, ExpiredAt);
        return Token;

        
    }
    
    
    private List<Claim> CreateClaim(Guid Id,string Email)
    {

        var Claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email,Email),
            new Claim(ClaimTypes.NameIdentifier,Id.ToString())

        };


        return Claims;



    }
    
    private SigningCredentials GetSigningCredentials(JwtSetting JWTOption)
    {

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTOption.Key));
        return new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);



    }
    
    private JwtSecurityToken GetJwtToken(JwtSetting JWTOption, List<Claim> claims, SigningCredentials SigningCredentials)
    {

        return new JwtSecurityToken(
            issuer: JWTOption.Issuer,
            audience: JWTOption.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(JWTOption.DurationInMinute),
            signingCredentials: SigningCredentials
        );

    }

    
    private RefreshToken GenerateRefreshToken()
    {

        var RandomNumber = new byte[32];
        var generator = new RNGCryptoServiceProvider();
        generator.GetBytes(RandomNumber);


        return new RefreshToken()
        {
            Token = Convert.ToBase64String(RandomNumber),
            ExpireAt = DateTime.UtcNow.AddDays(30),

        };

    }

    
    
    
    
    
    
    
    
    
}