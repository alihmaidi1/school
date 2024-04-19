using Shared.Entity.Interface;

namespace Shared.Services.Email;

public interface IMailService : IBaseSuper
{
    
    public bool SendMail(string email, string subject, string message);

    
}