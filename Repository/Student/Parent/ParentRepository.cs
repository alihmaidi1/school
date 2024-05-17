using Domain.Entities.Student.Parent;
using Dto.Student.Parent;
using infrastructure;
using Repository.Base;
using Shared.Entity.EntityOperation;

namespace Repository.Student.Parent;

public class ParentRepository:GenericRepository<Domain.Entities.Student.Parent.Parent>,IParentRepository
{
    public ParentRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public PageList<GetAllParentResponse> GetAllParent(string? OrderBy, int? pageNumber, int? pageSize)
    {

        // var Result = DbContext.Parents
        //     .Sort<Domain.Entities.Student.Parent.Parent>(OrderBy, ParentSorting.switchOrdering)
        //     .Select(ParentQuery.ToGetAllParent)
        //     .ToPagedList(pageNumber,pageSize);
        

        // return Result;

        return null;
    }


    public bool IsExists(Guid id)
    {

        return DbContext.Parents.Any(x=>x.Id.Equals(id));
    }



    public bool IsExists(string Email)
    {

        return DbContext.Parents.Any(x=>x.Email.Equals(Email));
    }

}