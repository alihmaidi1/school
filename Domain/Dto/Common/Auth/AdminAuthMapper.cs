using AutoMapper;
using Domain.Entities.Account;
using Dto.Admin.Auth.Dto;

namespace Dto.Admin.Auth;

public class AdminAuthMapper : Profile
{

    public AdminAuthMapper()
    {

        CreateMap<AccountSession,AdminRefreshTokenDto>().ReverseMap();
    }
    
}