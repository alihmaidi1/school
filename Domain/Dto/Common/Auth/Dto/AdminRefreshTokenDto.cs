namespace Dto.Admin.Auth.Dto;

public  class AdminRefreshTokenDto
{

    public string Token { get; set; }
    
    public string RefreshToken { get; set; }

    public DateTime ExpireAt { get; set; }

}