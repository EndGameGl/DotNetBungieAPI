namespace DotNetBungieAPI.Generated.Models;

public class GlobalAlert : IDeepEquatable<GlobalAlert>
{
    [JsonPropertyName("AlertKey")]
    public string AlertKey { get; set; }

    [JsonPropertyName("AlertHtml")]
    public string AlertHtml { get; set; }

    [JsonPropertyName("AlertTimestamp")]
    public DateTime AlertTimestamp { get; set; }

    [JsonPropertyName("AlertLink")]
    public string AlertLink { get; set; }

    [JsonPropertyName("AlertLevel")]
    public GlobalAlertLevel AlertLevel { get; set; }

    [JsonPropertyName("AlertType")]
    public GlobalAlertType AlertType { get; set; }

    [JsonPropertyName("StreamInfo")]
    public StreamInfo StreamInfo { get; set; }

    public bool DeepEquals(GlobalAlert? other)
    {
        return other is not null &&
               AlertKey == other.AlertKey &&
               AlertHtml == other.AlertHtml &&
               AlertTimestamp == other.AlertTimestamp &&
               AlertLink == other.AlertLink &&
               AlertLevel == other.AlertLevel &&
               AlertType == other.AlertType &&
               (StreamInfo is not null ? StreamInfo.DeepEquals(other.StreamInfo) : other.StreamInfo is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(GlobalAlert? other)
    {
        if (other is null) return;
        if (AlertKey != other.AlertKey)
        {
            AlertKey = other.AlertKey;
            OnPropertyChanged(nameof(AlertKey));
        }
        if (AlertHtml != other.AlertHtml)
        {
            AlertHtml = other.AlertHtml;
            OnPropertyChanged(nameof(AlertHtml));
        }
        if (AlertTimestamp != other.AlertTimestamp)
        {
            AlertTimestamp = other.AlertTimestamp;
            OnPropertyChanged(nameof(AlertTimestamp));
        }
        if (AlertLink != other.AlertLink)
        {
            AlertLink = other.AlertLink;
            OnPropertyChanged(nameof(AlertLink));
        }
        if (AlertLevel != other.AlertLevel)
        {
            AlertLevel = other.AlertLevel;
            OnPropertyChanged(nameof(AlertLevel));
        }
        if (AlertType != other.AlertType)
        {
            AlertType = other.AlertType;
            OnPropertyChanged(nameof(AlertType));
        }
        if (!StreamInfo.DeepEquals(other.StreamInfo))
        {
            StreamInfo.Update(other.StreamInfo);
            OnPropertyChanged(nameof(StreamInfo));
        }
    }
}