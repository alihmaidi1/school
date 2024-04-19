using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Entity.Entity;

namespace Domain.Entities.Account;

public class AccountSession : BaseEntity
{

    public string Token { get; set; }

    public DateTime ExpireAt { get; set; }


}