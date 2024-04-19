using Microsoft.AspNetCore.Authorization;

namespace infrastructure.Authorization.Requirement;

public class PermissionRequirement:IAuthorizationRequirement
{
 
    public string Permission { get; set; }    


    public PermissionRequirement(string permission)
    {
        this.Permission = permission;

    }

}