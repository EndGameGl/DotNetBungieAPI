using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetBungieAPI.AspNet.Security.OAuth.Providers;

public static class BungieNetAuthenticationExtensions
{
    /// <summary>
    /// Adds <see cref="BungieNetAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables BungieNet authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static AuthenticationBuilder AddBungieNet(
        this AuthenticationBuilder builder)
    {
        return builder.AddBungieNet(BungieNetAuthenticationDefaults.AuthenticationScheme, options => { });
    }
    
    /// <summary>
    /// Adds <see cref="BungieNetAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables AddBungieNet authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <param name="configuration">The delegate used to configure the OpenID 2.0 options.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static AuthenticationBuilder AddBungieNet(
        this AuthenticationBuilder builder,
        Action<BungieNetAuthenticationOptions> configuration)
    {
        return builder.AddBungieNet(BungieNetAuthenticationDefaults.AuthenticationScheme, configuration);
    }
    
    /// <summary>
    /// Adds <see cref="BungieNetAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables BungieNet authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <param name="scheme">The authentication scheme associated with this instance.</param>
    /// <param name="configuration">The delegate used to configure the BungieNet options.</param>
    /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
    public static AuthenticationBuilder AddBungieNet(
        this AuthenticationBuilder builder,
        string scheme,
        Action<BungieNetAuthenticationOptions> configuration)
    {
        return builder.AddBungieNet(scheme, BungieNetAuthenticationDefaults.DisplayName, configuration);
    }
    
    /// <summary>
    /// Adds <see cref="BungieNetAuthenticationHandler"/> to the specified
    /// <see cref="AuthenticationBuilder"/>, which enables BungieNet authentication capabilities.
    /// </summary>
    /// <param name="builder">The authentication builder.</param>
    /// <param name="scheme">The authentication scheme associated with this instance.</param>
    /// <param name="caption">The optional display name associated with this instance.</param>
    /// <param name="configuration">The delegate used to configure the BungieNet options.</param>
    /// <returns>The <see cref="AuthenticationBuilder"/>.</returns>
    public static AuthenticationBuilder AddBungieNet(
        this AuthenticationBuilder builder,
        string scheme,
        string? caption,
        Action<BungieNetAuthenticationOptions> configuration)
    {
        return builder.AddOAuth<BungieNetAuthenticationOptions, BungieNetAuthenticationHandler>(
            scheme,
            caption,
            configuration);
    }
}