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

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(AwaInitializeResponse? other)
    {
        if (other is null) return;
        if (CorrelationId != other.CorrelationId)
        {
            CorrelationId = other.CorrelationId;
            OnPropertyChanged(nameof(CorrelationId));
        }
        if (SentToSelf != other.SentToSelf)
        {
            SentToSelf = other.SentToSelf;
            OnPropertyChanged(nameof(SentToSelf));
        }
    }
}