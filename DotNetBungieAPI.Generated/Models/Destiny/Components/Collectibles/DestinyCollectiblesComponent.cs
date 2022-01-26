namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Collectibles;

public class DestinyCollectiblesComponent : IDeepEquatable<DestinyCollectiblesComponent>
{
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

    public bool DeepEquals(DestinyCollectiblesComponent? other)
    {
        return other is not null &&
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

    public void Update(DestinyCollectiblesComponent? other)
    {
        if (other is null) return;
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