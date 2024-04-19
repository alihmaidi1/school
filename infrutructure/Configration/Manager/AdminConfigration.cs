using Domain.Entities.Admin;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Role;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrutructure.Configration.Manager;

public class AdminConfigration:IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {

        builder.HasKey(Admin => Admin.Id);
        
        builder.Property(x => x.Status)
            .HasDefaultValue(true);
        builder.HasQueryFilter(x =>x.DateDeleted == null&& !x.Name.Equals(RoleEnum.SuperAdmin.ToString()));
        builder.Property(Admin => Admin.Id)
            .HasConversion(AdminID => AdminID.Value, Value => new AdminID(Value));


        builder.Property(Admin => Admin.RoleId)
            .HasConversion(RoleID => RoleID.Value, Value => new RoleID(Value));

        builder.HasOne<Role>(Admin => Admin.Role)
            .WithMany(Role => Role.Admins)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.RefreshTokens)
               .WithOne(x => x.Admin).OnDelete(DeleteBehavior.Cascade);


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