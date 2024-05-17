using Domain.Base.Entity;

namespace Domain.Entities.Account;

public class Account :BaseEntity 
{

    public Account()
    {

        AccountSessions = new List<AccountSession>();

        AccountNotifications=new HashSet<AccountNotification>();

        
    }
    

    public string Email{get;set;}
    public string Password{get;set;}
    public List<AccountSession> AccountSessions { get; set; }


    public ICollection<AccountNotification> AccountNotifications{get;set;}
    

    
    
}