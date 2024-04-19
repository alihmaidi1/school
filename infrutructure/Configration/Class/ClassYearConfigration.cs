using ClassDomain.Entities.StudentClass;
using Domain.Entities.Class.ClassYear;
using Domain.Entities.Class.Year;
using Domain.Entities.Subject.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrutructure.Configration.Class;

public class ClassYearConfigration:IEntityTypeConfiguration<ClassYear>
{
    public void Configure(EntityTypeBuilder<ClassYear> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, value => new ClassYearID(value));
        
        builder.Property(x => x.ClassId)
            .HasConversion(x => x.Value, value => new ClassID(value));
        
        
        
        builder.Property(x => x.YearId)
            .HasConversion(x => x.Value, value => new YearID(value));

        builder.HasIndex(x => new { x.YearId, x.ClassId })
            .IsUnique();

        builder.HasMany(x => x.Bills)
            .WithOne(x => x.ClassYear)
            .HasForeignKey(x => x.ClassYearId)
            .OnDelete(DeleteBehavior.Cascade);

        
        builder.HasMany(x => x.Students)
            .WithMany(x => x.ClassYears)
            .UsingEntity<StudentClass>();
        
        
        builder.HasMany(x => x.StudentClasses)
            .WithOne(x=>x.ClassYear)
            .HasForeignKey(x=>x.ClassYearId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}