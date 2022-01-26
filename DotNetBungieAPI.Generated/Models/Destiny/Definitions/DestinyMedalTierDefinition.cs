namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     An artificial construct of our own creation, to try and put some order on top of Medals and keep them from being one giant, unmanageable and unsorted blob of stats.
/// <para />
///     Unfortunately, we haven't had time to do this evaluation yet in Destiny 2, so we're short on Medal Tiers. This will hopefully be updated over time, if Medals continue to exist.
/// </summary>
public class DestinyMedalTierDefinition : IDeepEquatable<DestinyMedalTierDefinition>
{
    /// <summary>
    ///     The name of the tier.
    /// </summary>
    [JsonPropertyName("tierName")]
    public string TierName { get; set; }

    /// <summary>
    ///     If you're rendering medals by tier, render them in this order (ascending)
    /// </summary>
    [JsonPropertyName("order")]
    public int Order { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; set; }

    public bool DeepEquals(DestinyMedalTierDefinition? other)
    {
        return other is not null &&
               TierName == other.TierName &&
               Order == other.Order &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyMedalTierDefinition? other)
    {
        if (other is null) return;
        if (TierName != other.TierName)
        {
            TierName = other.TierName;
            OnPropertyChanged(nameof(TierName));
        }
        if (Order != other.Order)
        {
            Order = other.Order;
            OnPropertyChanged(nameof(Order));
        }
        if (Hash != other.Hash)
        {
            Hash = other.Hash;
            OnPropertyChanged(nameof(Hash));
        }
        if (Index != other.Index)
        {
            Index = other.Index;
            OnPropertyChanged(nameof(Index));
        }
        if (Redacted != other.Redacted)
        {
            Redacted = other.Redacted;
            OnPropertyChanged(nameof(Redacted));
        }
    }
}