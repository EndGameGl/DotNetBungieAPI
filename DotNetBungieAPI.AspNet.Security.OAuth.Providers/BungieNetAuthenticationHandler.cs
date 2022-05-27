using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DotNetBungieAPI.AspNet.Security.OAuth.Providers;

public partial class BungieNetAuthenticationHandler : OAuthHandler<BungieNetAuthenticationOptions>
{
    public BungieNetAuthenticationHandler(
        IOptionsMonitor<BungieNetAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticationTicket> CreateTicketAsync(
        ClaimsIdentity identity,
        AuthenticationProperties properties,
        OAuthTokenResponse tokens)
    {
        var membershipId = tokens.Response?.RootElement.GetString("membership_id");
        var userInfoEndpoint = string.Format(
            CultureInfo.InvariantCulture,
            Options.UserInformationEndpoint,
            membershipId);

        using var request = new HttpRequestMessage(HttpMethod.Get, userInfoEndpoint);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);
        request.Headers.Add("X-API-Key", Options.ApiKey);

        using var response = await Backchannel.SendAsync(
            request,
            HttpCompletionOption.ResponseHeadersRead,
            Context.RequestAborted);

        if (!response.IsSuccessStatusCode)
        {
            await Log.UserProfileErrorAsync(Logger, response, Context.RequestAborted);
            throw new HttpRequestException("An error occurred while retrieving the user profile.");
        }
        
        using var payload = JsonDocument.Parse(await response.Content.ReadAsStringAsync(Context.RequestAborted));
        
        var principal = new ClaimsPrincipal(identity);
        var context = new OAuthCreatingTicketContext(principal, properties, Context, Scheme, Options, Backchannel, tokens, payload.RootElement);
        context.RunClaimActions();
        
        await Events.CreatingTicket(context);
        return new AuthenticationTicket(context.Principal!, context.Properties, Scheme.Name);
    }

    private static partial class Log
    {
        internal static async Task UserProfileErrorAsync(ILogger logger, HttpResponseMessage response,
            CancellationToken cancellationToken)
        {
            UserProfileError(
                logger,
                response.StatusCode,
                response.Headers.ToString(),
                await response.Content.ReadAsStringAsync(cancellationToken));
        }

        [LoggerMessage(
            1,
            LogLevel.Error,
            "An error occurred while retrieving the user profile: the remote server returned a {Status} response with the following payload: {Headers} {Body}.")]
        private static partial void UserProfileError(
            ILogger logger,
            System.Net.HttpStatusCode status,
            string headers,
            string body);
    }
}