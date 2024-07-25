using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Teacher.Teacher.Query.GetAllSubject;

public class GetAllSubjectValidation: AbstractValidator<GetAllSubjectQuery>
{

    public GetAllSubjectValidation(ApplicationDbContext context){


        RuleFor(x=>x.SubjectId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Subjects.Any(x=>x.Id==id))
        .WithMessage("this Subject is not correct");

    }

}
