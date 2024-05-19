using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Quez;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Quez;

public class QuezConfiguration : IEntityTypeConfiguration<Domain.Entities.Quez.Quez>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Quez.Quez> builder)
    {

        builder.HasKey(x=>x.Id);
    
        builder.HasMany(x=>x.StudentQuezs)
        .WithOne(x=>x.Quez)
        .HasForeignKey(x=>x.QuezId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x=>x.Questions)
        .WithOne(x=>x.Quez)
        .HasForeignKey(x=>x.QuezId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
