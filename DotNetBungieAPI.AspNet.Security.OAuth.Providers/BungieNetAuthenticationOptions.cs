using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace DotNetBungieAPI.AspNet.Security.OAuth.Providers;

using System.Security.Claims;

public class BungieNetAuthenticationOptions : OAuthOptions
{
    public string ApiKey { get; set; } = string.Empty;

    public BungieNetAuthenticationOptions()
    {
        ClaimsIssuer = BungieNetAuthenticationDefaults.Issuer;
        CallbackPath = BungieNetAuthenticationDefaults.CallbackPath;
        AuthorizationEndpoint = BungieNetAuthenticationDefaults.AuthorizationEndpoint;
        TokenEndpoint = BungieNetAuthenticationDefaults.TokenEndpoint;
        UserInformationEndpoint = BungieNetAuthenticationDefaults.UserInformationEndpointFormat;

        ClaimActions.MapJsonSubKey(ClaimTypes.NameIdentifier, "Response", "membershipId");
        ClaimActions.MapJsonSubKey(ClaimTypes.Name, "Response", "displayName");
        ClaimActions.MapJsonSubKey(
            BungieNetAuthenticationConstants.Claims.UniqueName,
            "Response",
            "uniqueName"
        );
        ClaimActions.MapJsonSubKey(
            BungieNetAuthenticationConstants.Claims.ProfilePicturePath,
            "Response",
            "profilePicturePath"
        );
    }

    public override void Validate()
    {
        base.Validate();

        if (string.IsNullOrEmpty(ApiKey))
            throw new ArgumentException("Api key must be provided.", nameof(ApiKey));
    }
}
