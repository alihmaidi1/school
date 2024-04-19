using Domain.Entities.Role;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace infrastructure.Configration.Manager;

public class RoleConfiguration:IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(role => role.Id);
        builder.HasQueryFilter(x => !x.Name.Equals(RoleEnum.SuperAdmin.ToString()));
        
        
        builder.Property(x => x.Permissions)
            .HasConversion(permissions => JsonConvert.SerializeObject(permissions),
                permissions => JsonConvert.DeserializeObject<List<string>>(permissions));

    }
}