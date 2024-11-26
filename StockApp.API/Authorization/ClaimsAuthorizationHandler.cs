using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

public class ClaimsAuthorizationHandler : AuthorizationHandler<ClaimsAuthorizationRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ClaimsAuthorizationRequirement requirement)
    {
        if (context.User.HasClaim(c => c.Type == requirement.ClaimType && c.Value == requirement.ClaimValue))
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}