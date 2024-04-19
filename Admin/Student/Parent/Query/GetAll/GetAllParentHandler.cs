using Common.CQRS;
using Microsoft.AspNetCore.Mvc;
using Repository.Student.Parent;
using Shared.OperationResult;

namespace Admin.Student.Parent.Query.GetAll;

public class GetAllParentHandler:OperationResult,
    IQueryHandler<GetAllParentsQuery>
{
    private IParentRepository ParentRepository;


    public GetAllParentHandler(IParentRepository ParentRepository)
    {

        this.ParentRepository = ParentRepository;

    }
    public async Task<JsonResult> Handle(GetAllParentsQuery request, CancellationToken cancellationToken)
    {
        var Result = ParentRepository.GetAllParent(request.OrderBy,request.PageNumber,request.PageSize);

        return Success(Result,"this is all parent");
    }
}