namespace DotNetBungieAPI.Generated.Models.Destiny.Advanced;

public class AwaUserResponse : IDeepEquatable<AwaUserResponse>
{
    /// <summary>
    ///     Indication of the selection the user has made (Approving or rejecting the action)
    /// </summary>
    [JsonPropertyName("selection")]
    public Destiny.Advanced.AwaUserSelection Selection { get; set; }

    /// <summary>
    ///     Correlation ID of the request
    /// </summary>
    [JsonPropertyName("correlationId")]
    public string CorrelationId { get; set; }

    /// <summary>
    ///     Secret nonce received via the PUSH notification.
    /// </summary>
    [JsonPropertyName("nonce")]
    public List<string> Nonce { get; set; }

    public bool DeepEquals(AwaUserResponse? other)
    {
        return other is not null &&
               Selection == other.Selection &&
               CorrelationId == other.CorrelationId &&
               Nonce.DeepEqualsListNaive(other.Nonce);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(AwaUserResponse? other)
    {
        if (other is null) return;
        if (Selection != other.Selection)
        {
            Selection = other.Selection;
            OnPropertyChanged(nameof(Selection));
        }
        if (CorrelationId != other.CorrelationId)
        {
            CorrelationId = other.CorrelationId;
            OnPropertyChanged(nameof(CorrelationId));
        }
        if (!Nonce.DeepEqualsListNaive(other.Nonce))
        {
            Nonce = other.Nonce;
            OnPropertyChanged(nameof(Nonce));
        }
    }
}