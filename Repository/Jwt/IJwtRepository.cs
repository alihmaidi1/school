using Domain.Base.Entity;
using Domain.Entities.Account;
using Dto;
using Shared.Entity.Interface;

namespace Repository.Jwt;

public interface IJwtRepository : IBaseSuperTransient
{
    public Task<AccountSession> GetTokensInfo(Guid id,string email,string type,List<string>? permissions);

    public string GetToken(Guid id,string email,string type,List<string>? permissions);

    
}