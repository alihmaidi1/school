using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entity.Entity;

namespace Domain.Entities.Account;

public class Notification:BaseEntity
{


    public Notification(){

        Id=Guid.NewGuid();

        AccountNotifications=new HashSet<AccountNotification>();
    }


    public string Title{get;set;}

    public string Body{get;set;}


    public ICollection<AccountNotification> AccountNotifications{get;set;}



}
