using Domain.Base.Entity;

namespace Domain.Entities.Admin;

public class AdminRefreshToken:RefreshToken
{
    
    
    public  Admin Admin { get; set; }
    
    
}