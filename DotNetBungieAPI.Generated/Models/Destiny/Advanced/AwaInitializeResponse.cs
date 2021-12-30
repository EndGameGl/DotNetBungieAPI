using System.Text.Json.Serialization;

namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public sealed class AwaInitializeResponse
{

    /// <summary>
    ///     ID used to get the token. Present this ID to the user as it will identify this specific request on their device.
    /// </summary>
    [JsonPropertyName("correlationId")]
    public string CorrelationId { get; init; }

    /// <summary>
    ///     True if the PUSH message will only be sent to the device that made this request.
    /// </summary>
    [JsonPropertyName("sentToSelf")]
    public bool SentToSelf { get; init; }
}
