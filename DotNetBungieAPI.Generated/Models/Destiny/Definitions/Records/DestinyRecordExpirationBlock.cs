namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Records;

/// <summary>
///     If this record has an expiration after which it cannot be earned, this is some information about that expiration.
/// </summary>
public class DestinyRecordExpirationBlock : IDeepEquatable<DestinyRecordExpirationBlock>
{
    [JsonPropertyName("hasExpiration")]
    public bool HasExpiration { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    public bool DeepEquals(DestinyRecordExpirationBlock? other)
    {
        return other is not null &&
               HasExpiration == other.HasExpiration &&
               Description == other.Description &&
               Icon == other.Icon;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyRecordExpirationBlock? other)
    {
        if (other is null) return;
        if (HasExpiration != other.HasExpiration)
        {
            HasExpiration = other.HasExpiration;
            OnPropertyChanged(nameof(HasExpiration));
        }
        if (Description != other.Description)
        {
            Description = other.Description;
            OnPropertyChanged(nameof(Description));
        }
        if (Icon != other.Icon)
        {
            Icon = other.Icon;
            OnPropertyChanged(nameof(Icon));
        }
    }
}