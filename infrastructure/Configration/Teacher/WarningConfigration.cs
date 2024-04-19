using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Teacher;
using Domain.Entities.Teacher.Warning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Teacher;

public class WarningConfigration:IEntityTypeConfiguration<Warning>
{
    public void Configure(EntityTypeBuilder<Warning> builder)
    {

        builder.HasKey(x => x.Id);
        
        
        
        
        
    }
}