using Domain.Entities.Student.Parent;
using Domain.Entities.Student.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Student;

public class StudentConfigration:IEntityTypeConfiguration<Domain.Entities.Student.Student.Student>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Student.Student.Student> builder)
    {
        

        builder.HasMany(x=>x.Audiences)
        .WithOne(x=>x.Student)
        .HasForeignKey(x=>x.StudentId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x=>x.StudentBills)
        .WithOne(x=>x.Student)
        .HasForeignKey(x=>x.StudentId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x=>x.StudentSubjects)
        .WithOne(x=>x.Student)
        .HasForeignKey(x=>x.StudentId)
        .OnDelete(DeleteBehavior.Cascade);

        
    }
}