using System.Linq.Expressions;
using Dto.Student.Parent;

namespace Repository.Student.Parent;

public class ParentQuery
{
    public static Expression<Func<Domain.Entities.Student.Parent.Parent, GetAllParentResponse>> ToGetAllParent = Parent =>
        new GetAllParentResponse()
        {
            Id = Parent.Id,
            Name = Parent.Name,
            Email = Parent.Email,
            Image = Parent.Image,
            Resize = Parent.Resize,
            Hash = Parent.Hash
            
        };

}