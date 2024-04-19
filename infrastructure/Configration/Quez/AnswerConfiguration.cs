using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Quez;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Quez;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {

        builder.HasMany(x=>x.StudentAnswers)
        .WithOne(x=>x.Answer)
        .HasForeignKey(x=>x.AnswerId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}
