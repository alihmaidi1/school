using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Programm.Command.Add;

public class AddProgrammValidation: AbstractValidator<AddProgrammCommand>
{

    public AddProgrammValidation(ApplicationDbContext context){


        // RuleFor(x=>x.ClassId)
        // .NotEmpty()
        // .NotNull()
        // .Must(id=>context.Subjects.Any(x=>x.ClassId==id&&x.SubjectYears.Any(x=>x.Year.Date.Year==DateTime.Now.Year)))
        // .WithMessage("this class is not start in this year")
        // .Must(id=>!context.Subjects.Where(x=>x.ClassId==id).SelectMany(x=>x.SubjectYears.Where(x=>x.Year.Date.Year==DateTime.Now.Year)).SelectMany(x=>x.Programs).Any())
        // .WithMessage("this class already have programm");

        RuleForEach(x=>x.Programms.Select(x=>x.Day).ToList())
        .IsInEnum();

        RuleFor(x=>x.Programms.SelectMany(x=>x.ProgrammInfos).Select(x=>x.SubjectId).Distinct().ToList())
        .Must((request,subjectIds)=>context.Subjects.Where(x=>x.ClassId==request.ClassId).Select(x=>x.Id).Count()==subjectIds.Count())
        .WithMessage("some subjects are  not sended or not belongs to this class");



        RuleForEach(x=>x.Programms.SelectMany(x=>x.ProgrammInfos).ToList())
        .Must(x=>x.StartAt<x.EndAt)
        .WithMessage("subject startat time should be less than end at")
        ;        


        RuleForEach(x=>x.Programms)
        .ChildRules(programm=>{

            programm.RuleFor(x=>x.ProgrammInfos)
            .NotNull()
            .Must(x=>{

                var OrderedList=x.OrderBy(x=>x.StartAt).ToList();
                bool isValid=true;
                for (int i = 0; i < OrderedList.Count()-1; i++)
                {
                    
                    if(OrderedList[i].EndAt<=OrderedList[i+1].StartAt){

                        continue;
                    }
                    isValid=false;
                    break;
                    
                }

                return isValid;

            })
            .WithMessage("there are overlap between the time of lectures");

            

        });
        

    }

}
