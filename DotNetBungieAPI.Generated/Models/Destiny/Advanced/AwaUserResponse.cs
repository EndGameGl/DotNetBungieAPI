namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public sealed class AwaUserResponse
{

    /// <summary>
    ///     Indication of the selection the user has made (Approving or rejecting the action)
    /// </summary>
    [JsonPropertyName("selection")]
    public Destiny.Advanced.AwaUserSelection Selection { get; init; }

    /// <summary>
    ///     Correlation ID of the request
    /// </summary>
    [JsonPropertyName("correlationId")]
    public string CorrelationId { get; init; }

    /// <summary>
    ///     Secret nonce received via the PUSH notification.
    /// </summary>
    [JsonPropertyName("nonce")]
    public List<string> Nonce { get; init; }
}
