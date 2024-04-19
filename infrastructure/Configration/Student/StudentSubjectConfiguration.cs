using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Student.StudentSubject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Student;

public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
{
    public void Configure(EntityTypeBuilder<StudentSubject> builder)
    {


        
        builder.HasMany(x=>x.StudentQuezs)
        .WithOne(x=>x.StudentSubject)
        .HasForeignKey(x=>x.StudentSubjectId)
        .OnDelete(DeleteBehavior.Restrict);

    }
}
