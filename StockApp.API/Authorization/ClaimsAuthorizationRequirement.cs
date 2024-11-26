using Microsoft.AspNetCore.Authorization;

public class ClaimsAuthorizationRequirement : IAuthorizationRequirement
{
    public string ClaimType { get; }
    public string ClaimValue { get; }

    public ClaimsAuthorizationRequirement(string claimType, string claimValue)
    {
        ClaimType = claimType;
        ClaimValue = claimValue;
    }
}