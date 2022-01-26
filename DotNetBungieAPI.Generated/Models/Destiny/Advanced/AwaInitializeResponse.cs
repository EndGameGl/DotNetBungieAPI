namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public class AwaInitializeResponse : IDeepEquatable<AwaInitializeResponse>
{
    /// <summary>
    ///     ID used to get the token. Present this ID to the user as it will identify this specific request on their device.
    /// </summary>
    [JsonPropertyName("correlationId")]
    public string CorrelationId { get; set; }

    /// <summary>
    ///     True if the PUSH message will only be sent to the device that made this request.
    /// </summary>
    [JsonPropertyName("sentToSelf")]
    public bool SentToSelf { get; set; }

    public bool DeepEquals(AwaInitializeResponse? other)
    {
        return other is not null &&
               CorrelationId == other.CorrelationId &&
               SentToSelf == other.SentToSelf;
    }
}