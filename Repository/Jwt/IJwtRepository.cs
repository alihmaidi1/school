using Domain.Base.Entity;
using Dto;

namespace Repository.Jwt;

public interface IJwtRepository
{
    public Task<(RefreshToken refreshToken,string token,int ExpiredAt)> GetTokensInfo(Guid Id,string Email);

    public string GetToken(Guid Id,string Email);

    
}