using Shared.Entity.Entity;

namespace Domain.Entities.Account;

public class Account :BaseEntity 
{

    public Account()
    {

        AccountSessions = new List<AccountSession>();

    }
    

    public string Email{get;set;}
    public string Password{get;set;}
    public List<AccountSession> AccountSessions { get; set; }
    
    
    
}