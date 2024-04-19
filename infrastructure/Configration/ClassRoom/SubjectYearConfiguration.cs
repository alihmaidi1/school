using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.ClassRoom;

public class SubjectYearConfiguration : IEntityTypeConfiguration<SubjectYear>
{
    public void Configure(EntityTypeBuilder<SubjectYear> builder)
    {

        builder.HasMany(x=>x.Lesons)
        .WithOne(x=>x.SubjectYear)
        .HasForeignKey(x=>x.SubjectYearId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
