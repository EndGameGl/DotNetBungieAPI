namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions;

/// <summary>
///     Data about an item's "sources": ways that the item can be obtained.
/// </summary>
public class DestinyItemSourceBlockDefinition : IDeepEquatable<DestinyItemSourceBlockDefinition>
{
    /// <summary>
    ///     The list of hash identifiers for Reward Sources that hint where the item can be found (DestinyRewardSourceDefinition).
    /// </summary>
    [JsonPropertyName("sourceHashes")]
    public List<uint> SourceHashes { get; set; }

    /// <summary>
    ///     A collection of details about the stats that were computed for the ways we found that the item could be spawned.
    /// </summary>
    [JsonPropertyName("sources")]
    public List<Destiny.Definitions.Sources.DestinyItemSourceDefinition> Sources { get; set; }

    /// <summary>
    ///     If we found that this item is exclusive to a specific platform, this will be set to the BungieMembershipType enumeration that matches that platform.
    /// </summary>
    [JsonPropertyName("exclusive")]
    public BungieMembershipType Exclusive { get; set; }

    /// <summary>
    ///     A denormalized reference back to vendors that potentially sell this item.
    /// </summary>
    [JsonPropertyName("vendorSources")]
    public List<Destiny.Definitions.DestinyItemVendorSourceReference> VendorSources { get; set; }

    public bool DeepEquals(DestinyItemSourceBlockDefinition? other)
    {
        return other is not null &&
               SourceHashes.DeepEqualsListNaive(other.SourceHashes) &&
               Sources.DeepEqualsList(other.Sources) &&
               Exclusive == other.Exclusive &&
               VendorSources.DeepEqualsList(other.VendorSources);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyItemSourceBlockDefinition? other)
    {
        if (other is null) return;
        if (!SourceHashes.DeepEqualsListNaive(other.SourceHashes))
        {
            SourceHashes = other.SourceHashes;
            OnPropertyChanged(nameof(SourceHashes));
        }
        if (!Sources.DeepEqualsList(other.Sources))
        {
            Sources = other.Sources;
            OnPropertyChanged(nameof(Sources));
        }
        if (Exclusive != other.Exclusive)
        {
            Exclusive = other.Exclusive;
            OnPropertyChanged(nameof(Exclusive));
        }
        if (!VendorSources.DeepEqualsList(other.VendorSources))
        {
            VendorSources = other.VendorSources;
            OnPropertyChanged(nameof(VendorSources));
        }
    }
}