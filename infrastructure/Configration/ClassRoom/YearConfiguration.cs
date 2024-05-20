using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace infrastructure.Configration.ClassRoom;

public class YearConfiguration : IEntityTypeConfiguration<Year>
{


    public void Configure(EntityTypeBuilder<Year> builder)
    {    
        
        builder.HasMany(x=>x.ClassYears)
        .WithOne(x=>x.Year)
        .HasForeignKey(x=>x.YearId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
