using Domain.Base.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrutructure.Configration.Common;

public class ImageConfigration:IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.UseTptMappingStrategy();
    }
}