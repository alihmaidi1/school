namespace Shared.Services.Email;

public interface IMailService
{
    
    public bool SendMail(string Email,string message);

    
}