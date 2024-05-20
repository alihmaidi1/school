using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.ClassRoom;

public class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.HasKey(x=>x.Id);

        builder.HasMany(x=>x.StudentBills)
        .WithOne(x=>x.Bill)
        .HasForeignKey(x=>x.BillId)
        .OnDelete(DeleteBehavior.Restrict);

    }
}
