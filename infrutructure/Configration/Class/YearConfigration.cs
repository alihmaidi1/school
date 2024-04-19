using Domain.Entities.Class.Year;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrutructure.Configration.Class;

public class YearConfigration:IEntityTypeConfiguration<Year>
{
    
    
    public void Configure(EntityTypeBuilder<Year> builder)
    {

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new YearID(Value));


        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.HasMany(x => x.ClassYears)
            .WithOne(x => x.Year)
            .HasForeignKey(x => x.YearId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}