using Microsoft.AspNetCore.Authorization;

namespace infrutructure.Authorization.Requirement;

public class PermissionRequirement:IAuthorizationRequirement
{
 
    public string Permission { get; set; }    


    public PermissionRequirement(string Permission)
    {
        this.Permission = Permission;

    }

}