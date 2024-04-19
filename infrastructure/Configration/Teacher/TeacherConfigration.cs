using Domain.Entities.ClassRoom;
using Domain.Entities.Teacher.Teacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Teacher;

public class TeacherConfigration:IEntityTypeConfiguration<Domain.Entities.Teacher.Teacher.Teacher>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Teacher.Teacher.Teacher> builder)
    {

      

        builder.HasMany(x => x.Vacations)
            .WithOne(x => x.Teacher)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Warnings)
            .WithOne(x => x.Teacher)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x=>x.SubjectYears)
            .WithOne(x=>x.Teacher)
            .HasForeignKey(x=>x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        
        builder.HasMany(x=>x.Subjects)
        .WithMany(x=>x.Teachers)
        .UsingEntity<SubjectYear>();

    }
}