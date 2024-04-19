using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Teacher;
using Domain.Entities.Teacher.Warning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrutructure.Configration.Teacher;

public class WarningConfigration:IEntityTypeConfiguration<Warning>
{
    public void Configure(EntityTypeBuilder<Warning> builder)
    {

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new WarningID(Value));
        
        builder.Property(x => x.TeacherId)
            .HasConversion(x => x.Value, Value => new TeacherID(Value));

        
        builder.Property(x => x.AdminId)
            .HasConversion(x => x.Value, Value => new AdminID(Value));

        
    }
}