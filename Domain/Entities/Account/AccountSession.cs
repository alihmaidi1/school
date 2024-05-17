using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base.Entity;

namespace Domain.Entities.Account;

public class AccountSession : BaseEntity
{

    public string Token { get; set; }
    
    public string RefreshToken { get; set; }

    public DateTime ExpireAt { get; set; }
    
    public Account Account { get; set; }
    
    public Guid AccountId { get; set; }


}