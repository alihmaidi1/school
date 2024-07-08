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

        builder.HasMany(x=>x.Quezs)
        .WithOne(x=>x.SubjectYear)
        .HasForeignKey(x=>x.SubjectYearId)
        .OnDelete(DeleteBehavior.Restrict);

        // builder.HasOne(x=>x.TeacherSubject)
        // .WithMany(x=>x.SubjectYears)
        // .HasForeignKey(x=>x.TeacherSubjectId)
        // .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.Teacher)
            .WithMany(x=>x.SubjectYears)
            .HasForeignKey(x=>x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x=>x.Subject)
            .WithMany(x=>x.SubjectYear)
            .HasForeignKey(x=>x.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasMany(x=>x.Programs)
        .WithOne(x=>x.SubjectYear)
        .HasForeignKey(x=>x.SubjectYearId)
        .OnDelete(DeleteBehavior.Restrict);


        builder.HasMany(x=>x.StudentSubjects)
        .WithOne(x=>x.SubjectYear)
        .HasForeignKey(x=>x.SubjectYearId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x=>x.Audiences)
        .WithOne(x=>x.SubjectYear)
        .HasForeignKey(x=>x.SubjectYearId)
        .OnDelete(DeleteBehavior.Restrict);


    }
}
