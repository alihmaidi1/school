using Domain.Entities.Manager.Admin;
using Domain.Entities.Role;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configuration.Manager;

public class AdminConfigration:IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {


        builder.Property(x => x.Status)
            .HasDefaultValue(true);

        
        
        builder.HasOne<Role>(admin => admin.Role)
            .WithMany(role => role.Admins)
            .OnDelete(DeleteBehavior.Restrict);



        builder.HasMany(x => x.Vacations)
            .WithOne(x => x.Admin)
            .HasForeignKey(x => x.AdminId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.Warnings)
            .WithOne(x => x.Admin)
            .HasForeignKey(x => x.AdminId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}