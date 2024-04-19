using Domain.Entities.Student.Parent;
using Domain.Entities.Student.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrutructure.Configration.Student;

public class StudentConfigration:IEntityTypeConfiguration<Domain.Entities.Student.Student.Student>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Student.Student.Student> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new StudentID(Value));
        
        builder.Property(x => x.ParentId)
            .HasConversion(x => x.Value, Value => new ParentID(Value));
        
        builder.HasMany(x => x.StudentClasses)
            .WithOne(x => x.Student)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        
    }
}