using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;

namespace infrastructure.Data.Notification;

public class AccountNotificationFaker
{


    public static Faker<Domain.Entities.Account.AccountNotification> GetFaker(List<Guid> Accounts,List<Guid> Notifications)
    {

        var AccountNotification=new Faker<Domain.Entities.Account.AccountNotification>();
        AccountNotification.RuleFor(x=>x.AccountId,setter=>setter.PickRandom(Accounts));
        AccountNotification.RuleFor(x=>x.NotificationId,setter=>setter.PickRandom(Notifications));
        return AccountNotification;

    }

}
