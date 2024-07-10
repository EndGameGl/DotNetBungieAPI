using DotNetBungieAPI.Models.Authorization;

namespace DotNetBungieAPI.Models.Exceptions;

public class BungieNetAuthorizationErrorException : Exception
{
    /// <summary>
    ///     This will usually contain the error encountered when making authentication request
    /// </summary>
    public AuthorizationResponseError? Error { get; }

    /// <summary>
    ///     Raw error string if parsing failed
    /// </summary>
    public string? RawErrorBody { get; }

    public BungieNetAuthorizationErrorException(
        AuthorizationResponseError? error,
        string? rawErrorBody
    )
        : base(
            $"{(error is null ? "Failed to authenticate" : $"Failed to authenticate with error: {error.Error}")}"
        )
    {
        Error = error;
        RawErrorBody = rawErrorBody;
    }
}
