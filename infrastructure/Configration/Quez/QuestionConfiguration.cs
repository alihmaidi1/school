using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Quez;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Quez;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
     
        builder.HasMany(x=>x.Answers)
        .WithOne(x=>x.Question)
        .HasForeignKey(x=>x.QuestionId)
        .OnDelete(DeleteBehavior.Restrict);


        

    }
}
