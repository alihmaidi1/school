using Common.CQRS;

namespace Admin.Manager.Admin.Query.Get;

public class GetAdminQuery:IQuery
{


    public GetAdminQuery(Guid id)
    {

        this.id = id;
    }
    public Guid id { get; set; } 
    
}