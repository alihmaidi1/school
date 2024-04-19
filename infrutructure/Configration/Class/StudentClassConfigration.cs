using ClassDomain.Entities.StudentClass;
using Domain.Entities.Class.ClassYear;
using Domain.Entities.Class.StudentClass;
using Domain.Entities.Student.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrutructure.Configration.Class;

public class StudentClassConfigration:IEntityTypeConfiguration<StudentClass>
{
    public void Configure(EntityTypeBuilder<StudentClass> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new StudentClassID(Value));
        
        builder.Property(x => x.StudentId)
            .HasConversion(x => x.Value, Value => new StudentID(Value));


        builder.Property(x => x.ClassYearId)
            .HasConversion(x => x.Value, Value => new ClassYearID(Value));

        
        
    }
}