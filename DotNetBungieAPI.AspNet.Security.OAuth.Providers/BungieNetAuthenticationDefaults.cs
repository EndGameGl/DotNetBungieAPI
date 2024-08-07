﻿namespace DotNetBungieAPI.AspNet.Security.OAuth.Providers;

/// <summary>
///     Default values used by the Bungie.net authentication middleware.
/// </summary>
public static class BungieNetAuthenticationDefaults
{
    /// <summary>
    ///     Default value for <see cref="AuthenticationScheme.Name"/>.
    /// </summary>
    public const string AuthenticationScheme = "BungieNet";

    /// <summary>
    ///     Default value for <see cref="AuthenticationScheme.DisplayName"/>.
    /// </summary>
    public static readonly string DisplayName = "BungieNet";

    /// <summary>
    ///     Default value for <see cref="AuthenticationSchemeOptions.ClaimsIssuer"/>.
    /// </summary>
    public static readonly string Issuer = "BungieNet";

    /// <summary>
    ///     Default value for <see cref="RemoteAuthenticationOptions.CallbackPath"/>.
    /// </summary>
    public static readonly string CallbackPath = "/signin-bungienet";

    /// <summary>
    ///     Default value for <see cref="OAuthOptions.AuthorizationEndpoint"/>.
    /// </summary>
    public static readonly string AuthorizationEndpoint =
        "https://www.bungie.net/en/oauth/authorize";

    /// <summary>
    ///     Default value for <see cref="OAuthOptions.TokenEndpoint"/>.
    /// </summary>
    public static readonly string TokenEndpoint =
        "https://www.bungie.net/platform/app/oauth/token/";

    /// <summary>
    ///     Default value for <see cref="OAuthOptions.UserInformationEndpoint"/>.
    /// </summary>
    public static readonly string UserInformationEndpointFormat =
        "https://www.bungie.net/Platform/User/GetBungieNetUserById/{0}";
}
