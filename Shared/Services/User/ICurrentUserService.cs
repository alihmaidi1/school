using Shared.Entity.Interface;

namespace Shared.Services.User;

public interface ICurrentUserService : IBaseSuper
{
    

    public Guid? GetUserid();

    public bool IsAdmin();
    

    public string? Token { get;  }

    public string? getToken();

    
}