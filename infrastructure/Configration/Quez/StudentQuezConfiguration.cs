using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Quez;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace infrastructure.Configration.Quez;

public class StudentQuezConfiguration:IEntityTypeConfiguration<StudentQuez>
{
    public void Configure(EntityTypeBuilder<StudentQuez> builder)
    {

        builder.HasMany(x=>x.StudentAnswers)
        .WithOne(x=>x.StudentQuez)
        .HasForeignKey(x=>x.StudentQuizId)
        .OnDelete(DeleteBehavior.Restrict);


        


    }



}
