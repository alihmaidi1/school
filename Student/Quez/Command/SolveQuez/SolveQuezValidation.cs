using Microsoft.EntityFrameworkCore;
using FluentValidation;
using infrastructure;

namespace Student.Quez.Command.SolveQuez;

public class SolveQuezValidation: AbstractValidator<SolveQuezCommand>
{

    public SolveQuezValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.StudentQuezs.Any(x=>x.Id==id&&x.Quez.EndAt>DateTimeOffset.UtcNow))
        .WithMessage("this quez not exists or it is already finished");


        RuleFor(x=>x.Answers)
        .Must((request,x)=>{

            var Quez=context
            .StudentQuezs
            .AsNoTracking()
            .Where(x=>x.Id==request.Id)        
            .Include(x=>x.Quez)
            .ThenInclude(x=>x.Questions)    
            .ThenInclude(x=>x.Answers)                            
            .First();

            foreach (var item in Quez.Quez.Questions)
            {
                if(item.Answers.Where(x=>request.Answers.Contains(x.Id)).Count()>1)
                return false;
                
            }
            

            return true;




        });

    }

}
