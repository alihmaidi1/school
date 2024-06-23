using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Data.Notification;

namespace infrastructure.Seed.Notification;

public static class NotificationSeeder
{


    public static async Task seedData(ApplicationDbContext context){


        if(!context.Notifications.Any()){


            var Notifications=NotificationFaker.GetFaker().Generate(10).ToList();
            context.Notifications.AddRange(Notifications);
            context.SaveChanges();

        }

    }


}
