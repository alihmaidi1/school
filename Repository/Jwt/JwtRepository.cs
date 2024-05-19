using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Domain.Entities.Account;
using infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Jwt;

namespace Repository.Jwt;

public class JwtRepository:IJwtRepository
{
    private readonly JwtSetting _jwtOption;
    public readonly ApplicationDbContext Context; 


    public JwtRepository(IOptions<JwtSetting> setting, ApplicationDbContext dbContext)
    {
        this.Context = dbContext;
        this._jwtOption = setting.Value;
    }
    
    public Task<AccountSession> GetTokensInfo(Guid id,string email,string type,List<string>? permissions)  
    {
        
        
        string token = GetToken(id,email,type,permissions);
        string refreshToken = GenerateRefreshToken();
        return Task.FromResult(new AccountSession()
        {

            Token = token,
            RefreshToken = refreshToken,
            ExpireAt = DateTime.Now.AddDays(30),
            AccountId = id

        });

    }

    
    
    
    
    public string GetToken(Guid id,string email,string type,List<string>? permissions)
    {
        var claims = CreateClaim(id,email,permissions);
        var signingCredentials = GetSigningCredentials(_jwtOption);
        var jwtToken = GetJwtToken(_jwtOption, claims, signingCredentials,type);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;

        
    }
    
    
    private List<Claim> CreateClaim(Guid id,string email,List<string>? permissions=null)
    {

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email,email),
            new Claim(ClaimTypes.NameIdentifier,id.ToString())

        };

        if (permissions is null)
        {

            return claims;
        }
        foreach (var permission in permissions)
        {
            claims.Add(new Claim(permission,permission));
            
        }
        return claims;



    }
    
    private SigningCredentials GetSigningCredentials(JwtSetting jwtOption)
    {

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.Key));
        return new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);



    }
    
    private JwtSecurityToken GetJwtToken(JwtSetting jwtOption, List<Claim> claims, SigningCredentials SigningCredentials,string type)
    {

        return new JwtSecurityToken(
            issuer: type,
            audience: type,
            claims: claims,
            expires: DateTime.Now.AddMinutes(jwtOption.DurationInMinute),
            signingCredentials: SigningCredentials
        );

    }

    
    private string GenerateRefreshToken()
    {

        var randomNumber = new byte[32];
        var generator = new RNGCryptoServiceProvider();
        generator.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);


    }

    
    
    
    
    
    
    
    
    
}