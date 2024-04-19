using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.ClassRoom;

public class LesonConfiguration : IEntityTypeConfiguration<Leson>
{



    public void Configure(EntityTypeBuilder<Leson> builder)
    {

        
    }
}
