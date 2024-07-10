namespace DotNetBungieAPI.Models.Requests;

public class AwaUserResponse
{
    public AwaUserResponse(AwaUserSelection selection, string correlationId, byte[] nonce)
    {
        Selection = selection;
        CorrelationId = correlationId;
        Nonce = nonce;
    }

    /// <summary>
    ///     Indication of the selection the user has made (Approving or rejecting the action)
    /// </summary>
    [JsonPropertyName("selection")]
    public AwaUserSelection Selection { get; }

    /// <summary>
    ///     Correlation ID of the request
    /// </summary>
    [JsonPropertyName("correlationId")]
    public string CorrelationId { get; }

    /// <summary>
    ///     Secret nonce received via the PUSH notification.
    /// </summary>
    [JsonPropertyName("nonce")]
    public byte[] Nonce { get; }
}
