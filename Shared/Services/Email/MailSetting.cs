namespace Shared.Services.Email;

public class MailSetting
{
    public string From { get; init; }
    public string SmtpServer { get; init; }      
    public int Port { get; init; }               
    public string Username { get; init; }
    public string Password { get; init; }

    
}