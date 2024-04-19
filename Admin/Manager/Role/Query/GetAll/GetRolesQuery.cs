using Common.CQRS;

namespace Admin.Manager.Role.Query.GetAll;

public  class GetRolesQuery:IQuery
{
    

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }


    public string Search {get;set;}
}