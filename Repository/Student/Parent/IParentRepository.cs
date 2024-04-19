using Domain.Entities.Student.Parent;
using Dto.Student.Parent;
using Repository.Base;
using Shared.Entity.EntityOperation;

namespace Repository.Student.Parent;

public interface IParentRepository:IGenericRepository<Domain.Entities.Student.Parent.Parent>
{
    
    public PageList<GetAllParentResponse> GetAllParent(string? OrderBy, int? pageNumber, int? pageSize);


    public bool IsExists(Guid id);


    public bool IsExists(string Email);

}