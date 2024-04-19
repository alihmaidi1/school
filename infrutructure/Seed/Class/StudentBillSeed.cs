using ClassDomain.Entities.Bill;
using ClassDomain.Entities.StudentClass;
using Domain.Entities.Class.StudentBill;
using infrutructure.Data.Class;

namespace infrutructure.Seed.Class;

public static class StudentBillSeed
{
    
    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.StudentBills.Any())
        {

            List<Bill> bills = context.Bills.ToList();
            List<StudentClass> studentClasses = context.StudentClasses.ToList();
            List<StudentBill> studentBills = StudentBillFaker
                .GetStudentBillFaker(bills, studentClasses)
                .Generate(25)
                .DistinctBy(x=>new {x.BillId,x.StudentClassId})
                .ToList();
            context.StudentBills.AddRange(studentBills);
            context.SaveChanges();
            

        }
    }

    
}