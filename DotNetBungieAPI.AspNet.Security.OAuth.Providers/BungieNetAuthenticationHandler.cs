using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DotNetBungieAPI.AspNet.Security.OAuth.Providers;

public partial class BungieNetAuthenticationHandler : OAuthHandler<BungieNetAuthenticationOptions>
{
    public BungieNetAuthenticationHandler(
        IOptionsMonitor<BungieNetAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock
    )
        : base(options, logger, encoder, clock) { }

    protected override async Task<AuthenticationTicket> CreateTicketAsync(
        ClaimsIdentity identity,
        AuthenticationProperties properties,
        OAuthTokenResponse tokens
    )
    {
        var membershipId = tokens.Response?.RootElement.GetString("membership_id");
        var userInfoEndpoint = string.Format(
            CultureInfo.InvariantCulture,
            Options.UserInformationEndpoint,
            membershipId
        );

        using var request = new HttpRequestMessage(HttpMethod.Get, userInfoEndpoint);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);
        request.Headers.Add("X-API-Key", Options.ApiKey);

        using var response = await Backchannel.SendAsync(
            request,
            HttpCompletionOption.ResponseHeadersRead,
            Context.RequestAborted
        );

        if (!response.IsSuccessStatusCode)
        {
            await Log.UserProfileErrorAsync(Logger, response, Context.RequestAborted);
            throw new HttpRequestException("An error occurred while retrieving the user profile.");
        }

        using var payload = JsonDocument.Parse(
            await response.Content.ReadAsStringAsync(Context.RequestAborted)
        );

        var principal = new ClaimsPrincipal(identity);
        var context = new OAuthCreatingTicketContext(
            principal,
            properties,
            Context,
            Scheme,
            Options,
            Backchannel,
            tokens,
            payload.RootElement
        );
        context.RunClaimActions();

        await Events.CreatingTicket(context);
        return new AuthenticationTicket(context.Principal!, context.Properties, Scheme.Name);
    }

    protected override async Task<OAuthTokenResponse> ExchangeCodeAsync(
        OAuthCodeExchangeContext context
    )
    {
        var tokenRequestParameters = new List<KeyValuePair<string, string>>()
        {
            new("grant_type", "authorization_code"),
            new("code", context.Code),
            new("client_id", Options.ClientId),
            new("client_secret", Options.ClientSecret)
        };

        if (
            context.Properties.Items.TryGetValue(
                OAuthConstants.CodeVerifierKey,
                out var codeVerifier
            )
        )
        {
            tokenRequestParameters.Add(new(OAuthConstants.CodeVerifierKey, codeVerifier!));
            context.Properties.Items.Remove(OAuthConstants.CodeVerifierKey);
        }

        using var request = new HttpRequestMessage(HttpMethod.Post, Options.TokenEndpoint);

        request.Content = new FormUrlEncodedContent(tokenRequestParameters!);

        using var response = await Backchannel.SendAsync(request, Context.RequestAborted);

        if (!response.IsSuccessStatusCode)
        {
            await Log.ExchangeCodeErrorAsync(Logger, response, Context.RequestAborted);
            return OAuthTokenResponse.Failed(
                new Exception("An error occurred while retrieving an access token.")
            );
        }

        var payload = JsonDocument.Parse(
            await response.Content.ReadAsStringAsync(Context.RequestAborted)
        );

        return OAuthTokenResponse.Success(payload);
    }

    protected override string BuildChallengeUrl(
        AuthenticationProperties properties,
        string redirectUri
    )
    {
        var parameters = new Dictionary<string, string>
        {
            { "client_id", Options.ClientId },
            { "response_type", "code" },
        };

        if (Options.UsePkce)
        {
            var bytes = new byte[32];
            RandomNumberGenerator.Fill(bytes);
            var codeVerifier = Microsoft.AspNetCore.WebUtilities.Base64UrlTextEncoder.Encode(bytes);

            // Store this for use during the code redemption.
            properties.Items.Add(OAuthConstants.CodeVerifierKey, codeVerifier);

            var challengeBytes = SHA256.HashData(Encoding.UTF8.GetBytes(codeVerifier));
            var codeChallenge = WebEncoders.Base64UrlEncode(challengeBytes);

            parameters[OAuthConstants.CodeChallengeKey] = codeChallenge;
            parameters[OAuthConstants.CodeChallengeMethodKey] =
                OAuthConstants.CodeChallengeMethodS256;
        }

        parameters["state"] = Options.StateDataFormat.Protect(properties);

        return QueryHelpers.AddQueryString(Options.AuthorizationEndpoint, parameters!);
    }

    private static partial class Log
    {
        internal static async Task UserProfileErrorAsync(
            ILogger logger,
            HttpResponseMessage response,
            CancellationToken cancellationToken
        )
        {
            UserProfileError(
                logger,
                response.StatusCode,
                response.Headers.ToString(),
                await response.Content.ReadAsStringAsync(cancellationToken)
            );
        }

        internal static async Task ExchangeCodeErrorAsync(
            ILogger logger,
            HttpResponseMessage response,
            CancellationToken cancellationToken
        )
        {
            ExchangeCodeError(
                logger,
                response.StatusCode,
                response.Headers.ToString(),
                await response.Content.ReadAsStringAsync(cancellationToken)
            );
        }

        [LoggerMessage(
            1,
            LogLevel.Error,
            "An error occurred while retrieving the user profile: the remote server returned a {Status} response with the following payload: {Headers} {Body}."
        )]
        private static partial void UserProfileError(
            ILogger logger,
            System.Net.HttpStatusCode status,
            string headers,
            string body
        );

        [LoggerMessage(
            2,
            LogLevel.Error,
            "An error occurred while retrieving an access token: the remote server returned a {Status} response with the following payload: {Headers} {Body}."
        )]
        private static partial void ExchangeCodeError(
            ILogger logger,
            HttpStatusCode status,
            string headers,
            string body
        );
    }
}
