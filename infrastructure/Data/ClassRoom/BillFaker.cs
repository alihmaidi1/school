using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.ClassRoom;

namespace infrastructure.Data.ClassRoom;

public class BillFaker
{

    public static Faker<Bill> GetFaker(){

        var Bill=new Faker<Bill>();
        Bill.RuleFor(x=>x.Date,setter=>DateTime.Now.AddMonths(setter.Random.Int(1,6)));
        Bill.RuleFor(x=>x.Money,setter=>setter.Random.Int(1000,5000));
        return Bill;
    }
}
