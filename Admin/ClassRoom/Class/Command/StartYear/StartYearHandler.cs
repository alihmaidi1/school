using Domain.Entities.ClassRoom;
using Domain.Entities.Student.StudentSubject;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Command.StartYear;

public class StartYearHandler : OperationResult,ICommandHandler<StartYearCommand>
{


    private ApplicationDbContext _context;
    public StartYearHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(StartYearCommand request, CancellationToken cancellationToken)
    {


        var Year=_context.Years.FirstOrDefault(x=>x.Date.Year==DateTime.UtcNow.Year);
        if(Year is null){

            Year=new Domain.Entities.ClassRoom.Year{

                Date=DateTime.UtcNow,
            };

            _context.Years.Add(Year);
            _context.SaveChanges();

        }


        var Class=_context
        .Classes
        .Include(x=>x.Subjects)
        .AsNoTracking()
        .Where(x=>x.Id==request.ClassId)
        .First();

        var Students=_context
        .Students
        .AsNoTracking()
        .Where(x=>x.Level==Class.Level)
        .Where(x=>!x.StudentSubjects.Where(y=>y.SubjectYear.ClassYear.Status).Any())
        .Select(x=>x.Id)
        .ToList();


        var ClassYear=new ClassYear{


            ClassId=request.ClassId,
            YearId=Year.Id,
            SubjectYears=Class.Subjects.Select(x=>new SubjectYear{

                SubjectId=x.Id,
                StudentSubjects=Students.Select(x=>new StudentSubject{

                    StudentId=x


                }).ToList()

            }).ToList()

            
            
        };

        _context.ClassYears.Add(ClassYear);
        _context.SaveChanges();
        return Success();
    }
}
