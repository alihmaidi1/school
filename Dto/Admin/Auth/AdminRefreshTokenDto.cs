namespace Dto.Admin.Auth;

public static class AdminRefreshTokenDto
{

    public static Domain.Entities.Admin.AdminRefreshToken ToAdminRefreshToken(string Token,DateTime ExpiredAt)
    {

        return new Domain.Entities.Admin.AdminRefreshToken()
        {

            Token = Token,
            ExpireAt = ExpiredAt
            

        };


    }
    
    
}