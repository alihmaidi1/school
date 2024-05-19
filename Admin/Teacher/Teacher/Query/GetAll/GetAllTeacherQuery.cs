using Common.CQRS;
using Shared.Abstraction;

namespace Admin.Teacher.Teacher.Query.GetAll;

public class GetAllTeacherQuery: PaginationRequest,IQuery
{
    
    
    

    public string? Search{get;set;}

}