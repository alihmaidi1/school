using Domain.Base.Entity;
using Domain.Base.interfaces;

namespace Domain.Entities.Account;

public class Account :BaseEntity ,ISoftDelete
{

    public Account()
    {

        AccountSessions = new List<AccountSession>();

        AccountNotifications=new HashSet<AccountNotification>();

        
    }
    

    public string Email{get;set;}
    public string Password{get;set;}

    public string? ResetCode{get;set;}

    public string? Name{get;set;}
    public List<AccountSession> AccountSessions { get; set; }


    public bool Status{get;set;}=true;

    public ICollection<AccountNotification> AccountNotifications{get;set;}
    

    
    
}