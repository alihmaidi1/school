using Bogus;
using ClassDomain.Entities.Bill;
using ClassDomain.Entities.StudentClass;
using Domain.Entities.Class.StudentBill;

namespace infrutructure.Data.Class;

public static class StudentBillFaker
{
    
    public static Faker<StudentBill> GetStudentBillFaker(List<Bill> bills, List<StudentClass> studentClasses)
    {

        var studentBill = new Faker<StudentBill>();
        Bill Bill=new Faker().PickRandom(bills);
        studentBill.RuleFor(x => x.BillId, setter => Bill.Id);
        studentBill.RuleFor(x => x.StudentClassId, setter => setter.PickRandom(studentClasses).Id);
        return studentBill;

    }

    
}