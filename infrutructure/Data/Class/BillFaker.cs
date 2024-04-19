using Bogus;
using ClassDomain.Entities.Bill;
using Domain.Entities.Class.ClassYear;

namespace infrutructure.Data.Class;

public static class BillFaker
{
    

    public static Faker<Bill> GetBillFaker(List<ClassYear> classYears)
    {
        
        var Bill = new Faker<Bill>();
        Bill.RuleFor(x => x.Money, setter => setter.Internet.Random.Number(100, 1000));
        Bill.RuleFor(x => x.Date, setter => setter.Date.Between(DateTime.Now, DateTime.Now.AddMonths(10)));
        Bill.RuleFor(x => x.ClassYearId, setter => setter.PickRandom(classYears).Id);
        return Bill;
    }
    
}