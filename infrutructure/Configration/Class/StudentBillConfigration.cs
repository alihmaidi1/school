using Domain.Entities.Class.Bill;
using Domain.Entities.Class.StudentBill;
using Domain.Entities.Class.StudentClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrutructure.Configration.Class;

public class StudentBillConfigration:IEntityTypeConfiguration<StudentBill>
{
    public void Configure(EntityTypeBuilder<StudentBill> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new StudentBillID(Value));
        
        builder.Property(x => x.BillId)
            .HasConversion(x => x.Value, Value => new BillID(Value));
        
        builder.Property(x => x.StudentClassId)
            .HasConversion(x => x.Value, Value => new StudentClassID(Value));

        
        builder.HasOne(x => x.StudentClass)
            .WithMany(x => x.StudentBills)
            .HasForeignKey(x=>x.StudentClassId)
            .OnDelete(DeleteBehavior.Cascade);


        
    }
}