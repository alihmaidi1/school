using Domain.Entities.Teacher.Teacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrutructure.Configration.Teacher;

public class TeacherConfigration:IEntityTypeConfiguration<Domain.Entities.Teacher.Teacher.Teacher>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Teacher.Teacher.Teacher> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasQueryFilter(x => x.DateDeleted==null);
        
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new TeacherID(Value));

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.status)
            .HasDefaultValue(true);


        builder.HasMany(x => x.Vacations)
            .WithOne(x => x.Teacher)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Warnings)
            .WithOne(x => x.Teacher)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}