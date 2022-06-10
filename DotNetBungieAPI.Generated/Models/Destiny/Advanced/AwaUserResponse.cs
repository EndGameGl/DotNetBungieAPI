namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public class AwaUserResponse
{
    /// <summary>
    ///     Indication of the selection the user has made (Approving or rejecting the action)
    /// </summary>
    [JsonPropertyName("selection")]
    public Destiny.Advanced.AwaUserSelection? Selection { get; set; }

    /// <summary>
    ///     Correlation ID of the request
    /// </summary>
    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    /// <summary>
    ///     Secret nonce received via the PUSH notification.
    /// </summary>
    [JsonPropertyName("nonce")]
    public List<string> Nonce { get; set; }
}
