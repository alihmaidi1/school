using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.Account;

namespace infrastructure.Data.Notification;

public class NotificationFaker
{

    public static Faker<Domain.Entities.Account.Notification> GetFaker()
    {


        var Notification=new Faker<Domain.Entities.Account.Notification>();
        Notification.RuleFor(x=>x.Body,setter=>setter.Random.Words(1));
        Notification.RuleFor(x=>x.Title,setter=>setter.Random.Words(1));
        return Notification;


    }

}
