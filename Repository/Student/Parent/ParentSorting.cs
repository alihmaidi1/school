// using System.Linq.Expressions;

// namespace Repository.Student.Parent;

// public  class ParentSorting
// {
//     public static List<string> OrderBy = new List<string>()
//     {
//         "Name",
//     };

    
//     public static Func<string, Expression<Func<Domain.Entities.Student.Parent.Parent, object>>> switchOrdering= key
            
//         =>key switch
//         {

//             "Name" => x => x.Name,
//             _ => x => x.DateCreated,

//         };

    
// }