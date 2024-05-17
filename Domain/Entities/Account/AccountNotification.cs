using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Shared.Entity.Entity;

namespace Domain.Entities.Account;

public class AccountNotification:BaseEntity
{

    public AccountNotification(){


        Id=Guid.NewGuid();
    }


    public bool IsRead{get;set;}=false;

    public Guid AccountId{get;set;}

    public Account Account{get;set;}


    public Guid NotificationId{get;set;}


    public Notification Notification{get;set;}

}
