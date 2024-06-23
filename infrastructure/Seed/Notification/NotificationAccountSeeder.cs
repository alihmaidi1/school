using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enum;
using infrastructure.Data.Notification;

namespace infrastructure.Seed.Notification;

public static class NotificationAccountSeeder
{

    public static async Task seedData(ApplicationDbContext context){


        if(!context.AccountNotifications.Any()){

            var Notifications=context.Notifications.Select(x=>x.Id).ToList();
            var Account=context.Accounts.Select(x=>x.Id).ToList();

            var AccountNotifications=AccountNotificationFaker
            .GetFaker(Account,Notifications)
            .Generate(50)
            .Distinct()
            .ToList();
            context.AccountNotifications.AddRange(AccountNotifications);
            context.SaveChanges();

        }

    }


}
