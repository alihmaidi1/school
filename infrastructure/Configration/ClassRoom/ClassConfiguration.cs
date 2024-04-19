using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace infrastructure.Configration.ClassRoom;

public class ClassConfiguration : IEntityTypeConfiguration<Class>
{


    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.HasMany(x=>x.Subjects)
        .WithOne(x=>x.Class)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x=>x.Bills)
        .WithOne(x=>x.Class)
        .HasForeignKey(x=>x.ClassId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
