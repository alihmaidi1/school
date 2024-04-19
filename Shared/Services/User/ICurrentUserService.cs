using Shared.Entity.Interface;

namespace Shared.Services.User;

public interface ICurrentUserService : IBaseSuper
{
    
    Guid? UserId { get; init; }
    
    string? Token { get;  }

    
}