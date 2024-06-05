using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Teacher.Warning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Teacher;

public class VacationTypeConfiguration : IEntityTypeConfiguration<VacationType>
{
    public void Configure(EntityTypeBuilder<VacationType> builder)
    {

        builder.HasMany(x=>x.Vacations)
        .WithOne(x=>x.VacationType)
        .HasForeignKey(x=>x.TypeId)
        .OnDelete(DeleteBehavior.Restrict);


    }
}
