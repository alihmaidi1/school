using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.ClassRoom;

public class ClassYearConfiguration : IEntityTypeConfiguration<ClassYear>
{
    public void Configure(EntityTypeBuilder<ClassYear> builder)
    {

        builder.HasKey(x=>x.Id);
        builder.HasMany(x=>x.Bills)
        .WithOne(x=>x.ClassYear)
        .HasForeignKey(x=>x.ClassYearId)
        .OnDelete(DeleteBehavior.Restrict);


        builder.HasMany(x=>x.SubjectYears)
        .WithOne(x=>x.ClassYear)
        .HasForeignKey(x=>x.ClassYearId)
        .OnDelete(DeleteBehavior.Restrict);    

    }
}
