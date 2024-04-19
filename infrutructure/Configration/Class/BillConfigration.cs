using ClassDomain.Entities.Bill;
using Domain.Entities.Class.Bill;
using Domain.Entities.Class.ClassYear;
using Domain.Entities.Class.StudentBill;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrutructure.Configration.Class;

public class BillConfigration:IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new BillID(Value));
        
        
        builder.Property(x => x.ClassYearId)
            .HasConversion(x => x.Value, Value => new ClassYearID(Value));
        
        
        builder.HasMany(x => x.StudentBills)
            .WithOne(x => x.Bill)
            .HasForeignKey(x => x.BillId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(x => x.StudentClasses)
            .WithMany(x => x.Bills)
            .UsingEntity<StudentBill>();
        

    }
}