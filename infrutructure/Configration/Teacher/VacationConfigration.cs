using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Teacher;
using Domain.Entities.Teacher.Vacation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrutructure.Configration.Teacher;

public class VacationConfigration:IEntityTypeConfiguration<Vacation>
{
    public void Configure(EntityTypeBuilder<Vacation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new VacationID(Value));

        builder.Property(x => x.TeacherId)
            .HasConversion(x => x.Value, Value => new TeacherID(Value));
        
        builder.Property(x => x.AdminId)
            .HasConversion(x => x.Value, Value => new AdminID(Value));

        
    }
}