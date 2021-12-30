using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public enum AwaResponseReason : int
{
    None = 0,
    /// <summary>
    ///     User provided an answer
    /// </summary>
    Answered = 1,
    /// <summary>
    ///     The HTTP request timed out, a new request may be made and an answer may still be provided.
    /// </summary>
    TimedOut = 2,
    /// <summary>
    ///     This request was replaced by another request.
    /// </summary>
    Replaced = 3
}
