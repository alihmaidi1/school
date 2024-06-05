using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using Domain.Entities.Teacher.Teacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.ClassRoom;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {


        builder.HasMany(x=>x.TeacherSubjects)
        .WithOne(x=>x.Subject)
        .HasForeignKey(x=>x.SubjectId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
