// using Domain.Enum;
//
// namespace Domain.Attributes;
//
// public class AppAuthorizeAttribute:CheckTokenSessionAttribute
// {
//     public AppAuthorizeAttribute(params RoleEnum[] roles) { 
//         
//         if(roles.Length != 0)
//         {
//
//             
//             Roles = string.Join(",", roles.Select(x => x.ToString()));
//
//         }
//
//
//     }
//
//     
// }