using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Teacher;
using Domain.Entities.Teacher.Vacation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Teacher;

public class VacationConfigration:IEntityTypeConfiguration<Vacation>
{
    public void Configure(EntityTypeBuilder<Vacation> builder)
    {
        builder.HasKey(x => x.Id);
        
        
        
        
    }
}