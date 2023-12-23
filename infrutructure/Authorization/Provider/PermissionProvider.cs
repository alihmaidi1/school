using infrutructure.Authorization.Requirement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace infrutructure.Authorization.Provider;

public class PermissionProvider:IAuthorizationPolicyProvider
{
    public DefaultAuthorizationPolicyProvider DefaultAuthorizationPolicyProvider;

    public PermissionProvider(IOptions<AuthorizationOptions> options) {
        
        DefaultAuthorizationPolicyProvider=new DefaultAuthorizationPolicyProvider(options); 
    }

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        
        var Policy = new AuthorizationPolicyBuilder();
        Policy.AddRequirements(new PermissionRequirement(policyName));
        return Task.FromResult(Policy.Build());
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
    {
        
        return this.DefaultAuthorizationPolicyProvider.GetDefaultPolicyAsync();

    }

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
    {
        return this.DefaultAuthorizationPolicyProvider.GetFallbackPolicyAsync();

    }
}