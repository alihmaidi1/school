using Common.CQRS;
using Domain.Entities.Teacher.Teacher;
using Microsoft.AspNetCore.Mvc;
using Repository.Teacher.Vacation;
using Shared.OperationResult;

namespace Admin.Teacher.Vacation.Query.GetAll;

public class GetVacationsHandler:OperationResult,
    IQueryHandler<GetVacationQuery>
{
    private IVacationRepository VacationRepository;

    public GetVacationsHandler(IVacationRepository VacationRepository)
    {

        this.VacationRepository = VacationRepository;
    }
    
    public async Task<JsonResult> Handle(GetVacationQuery request, CancellationToken cancellationToken)
    {

        var Result = VacationRepository.GetAll(request.Status,request.TeacherId,request.PageNumber,request.PageSize);
        return Success(Result,"this is all vacation ");
    }
}