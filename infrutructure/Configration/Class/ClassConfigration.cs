using Domain.Entities.Subject.Class;
using Domain.Entities.Subject.Stage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrutructure.Configration.Class;

public class ClassConfigration:IEntityTypeConfiguration<Domain.Entities.Class.Class.Class>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Class.Class.Class> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, Value => new ClassID(Value));
        
        
        builder.Property(x => x.StageId)
            .HasConversion(x => x.Value, Value => new StageID(Value));

        builder.HasMany(x => x.ClassYears)
            .WithOne(x => x.Class)
            .HasForeignKey(x => x.ClassId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
}