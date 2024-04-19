using infrastructure.Authorization.Requirement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace infrastructure.Authorization.Provider;

public class PermissionProvider:IAuthorizationPolicyProvider
{
    private readonly DefaultAuthorizationPolicyProvider _defaultAuthorizationPolicyProvider;

    public PermissionProvider(IOptions<AuthorizationOptions> options) {
        
        _defaultAuthorizationPolicyProvider=new DefaultAuthorizationPolicyProvider(options); 
    }

    public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
        var policy = new AuthorizationPolicyBuilder();
        policy.AddRequirements(new PermissionRequirement(policyName));
        return Task.FromResult(policy.Build());
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
    {
        
        return this._defaultAuthorizationPolicyProvider.GetDefaultPolicyAsync();

    }

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
    {
        return this._defaultAuthorizationPolicyProvider.GetFallbackPolicyAsync();

    }
}