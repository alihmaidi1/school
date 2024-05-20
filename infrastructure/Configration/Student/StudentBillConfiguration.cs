using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Student.StudentBill;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Student;

public class StudentBillConfiguration : IEntityTypeConfiguration<StudentBill>
{
    public void Configure(EntityTypeBuilder<StudentBill> builder)
    {

        builder.HasKey(x=>x.Id);
        builder.HasOne(x=>x.Bill)
        .WithMany(x=>x.StudentBills)
        .HasForeignKey(x=>x.BillId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
