namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Collectibles;

public class DestinyProfileCollectiblesComponent : IDeepEquatable<DestinyProfileCollectiblesComponent>
{
    /// <summary>
    ///     The list of collectibles determined by the game as having been "recently" acquired.
    /// </summary>
    [JsonPropertyName("recentCollectibleHashes")]
    public List<uint> RecentCollectibleHashes { get; set; }

    /// <summary>
    ///     The list of collectibles determined by the game as having been "recently" acquired.
    /// <para />
    ///     The game client itself actually controls this data, so I personally question whether anyone will get much use out of this: because we can't edit this value through the API. But in case anyone finds it useful, here it is.
    /// </summary>
    [JsonPropertyName("newnessFlaggedCollectibleHashes")]
    public List<uint> NewnessFlaggedCollectibleHashes { get; set; }

    [JsonPropertyName("collectibles")]
    public Dictionary<uint, Destiny.Components.Collectibles.DestinyCollectibleComponent> Collectibles { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Collection categories.
    /// </summary>
    [JsonPropertyName("collectionCategoriesRootNodeHash")]
    public uint CollectionCategoriesRootNodeHash { get; set; }

    /// <summary>
    ///     The hash for the root presentation node definition of Collection Badges.
    /// </summary>
    [JsonPropertyName("collectionBadgesRootNodeHash")]
    public uint CollectionBadgesRootNodeHash { get; set; }

    public bool DeepEquals(DestinyProfileCollectiblesComponent? other)
    {
        return other is not null &&
               RecentCollectibleHashes.DeepEqualsListNaive(other.RecentCollectibleHashes) &&
               NewnessFlaggedCollectibleHashes.DeepEqualsListNaive(other.NewnessFlaggedCollectibleHashes) &&
               Collectibles.DeepEqualsDictionary(other.Collectibles) &&
               CollectionCategoriesRootNodeHash == other.CollectionCategoriesRootNodeHash &&
               CollectionBadgesRootNodeHash == other.CollectionBadgesRootNodeHash;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyProfileCollectiblesComponent? other)
    {
        if (other is null) return;
        if (!RecentCollectibleHashes.DeepEqualsListNaive(other.RecentCollectibleHashes))
        {
            RecentCollectibleHashes = other.RecentCollectibleHashes;
            OnPropertyChanged(nameof(RecentCollectibleHashes));
        }
        if (!NewnessFlaggedCollectibleHashes.DeepEqualsListNaive(other.NewnessFlaggedCollectibleHashes))
        {
            NewnessFlaggedCollectibleHashes = other.NewnessFlaggedCollectibleHashes;
            OnPropertyChanged(nameof(NewnessFlaggedCollectibleHashes));
        }
        if (!Collectibles.DeepEqualsDictionary(other.Collectibles))
        {
            Collectibles = other.Collectibles;
            OnPropertyChanged(nameof(Collectibles));
        }
        if (CollectionCategoriesRootNodeHash != other.CollectionCategoriesRootNodeHash)
        {
            CollectionCategoriesRootNodeHash = other.CollectionCategoriesRootNodeHash;
            OnPropertyChanged(nameof(CollectionCategoriesRootNodeHash));
        }
        if (CollectionBadgesRootNodeHash != other.CollectionBadgesRootNodeHash)
        {
            CollectionBadgesRootNodeHash = other.CollectionBadgesRootNodeHash;
            OnPropertyChanged(nameof(CollectionBadgesRootNodeHash));
        }
    }
}