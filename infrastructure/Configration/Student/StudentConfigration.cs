using Domain.Entities.Student.Parent;
using Domain.Entities.Student.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Student;

public class StudentConfigration:IEntityTypeConfiguration<Domain.Entities.Student.Student.Student>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Student.Student.Student> builder)
    {
        builder.HasKey(x => x.Id);
        

        
    }
}