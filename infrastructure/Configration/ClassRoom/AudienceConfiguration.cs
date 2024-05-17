using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Student.Audience;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.ClassRoom;
public class AudienceConfiguration : IEntityTypeConfiguration<Audience>
{
    public void Configure(EntityTypeBuilder<Audience> builder)
    {
        builder.HasKey(x=>x.Id);
    }
}
