using Shared.Entity.Interface;

namespace Shared.Services.User;

public interface ICurrentUserService : IBaseSuper
{
    

    public Guid? GetUserid();

    

    public string? Token { get;  }

    
}