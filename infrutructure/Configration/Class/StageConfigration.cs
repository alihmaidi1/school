using Domain.Entities.Subject.Stage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrutructure.Configration.Class;

public class StageConfigration:IEntityTypeConfiguration<Stage>
{
    public void Configure(EntityTypeBuilder<Stage> builder)
    {

        
        builder.HasKey(x => x.Id);


        builder.Property(x => x.Id)
            .HasConversion(x=>x.Value,Value=>new StageID(Value));

        builder.HasMany(x => x.Classes)
            .WithOne(x => x.Stage)
            .HasForeignKey(x=>x.StageId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}