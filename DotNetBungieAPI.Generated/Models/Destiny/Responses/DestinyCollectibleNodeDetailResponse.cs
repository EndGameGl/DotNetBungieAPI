namespace DotNetBungieAPI.Generated.Models.Destiny.Responses;

/// <summary>
///     Returns the detailed information about a Collectible Presentation Node and any Collectibles that are direct descendants.
/// </summary>
public class DestinyCollectibleNodeDetailResponse : IDeepEquatable<DestinyCollectibleNodeDetailResponse>
{
    /// <summary>
    ///     COMPONENT TYPE: Collectibles
    /// </summary>
    [JsonPropertyName("collectibles")]
    public SingleComponentResponseOfDestinyCollectiblesComponent Collectibles { get; set; }

    /// <summary>
    ///     Item components, keyed by the item hash of the items pointed at collectibles found under the requested Presentation Node.
    /// <para />
    ///     NOTE: I had a lot of hemming and hawing about whether these should be keyed by collectible hash or item hash... but ultimately having it be keyed by item hash meant that UI that already uses DestinyItemComponentSet data wouldn't have to have a special override to do the collectible -> item lookup once you delve into an item's details, and it also meant that you didn't have to remember that the Hash being used as the key for plugSets was different from the Hash being used for the other Dictionaries. As a result, using the Item Hash felt like the least crappy solution.
    /// <para />
    ///     We may all come to regret this decision. We will see.
    /// <para />
    ///     COMPONENT TYPE: [See inside the DestinyItemComponentSet contract for component types.]
    /// </summary>
    [JsonPropertyName("collectibleItemComponents")]
    public DestinyItemComponentSetOfuint32 CollectibleItemComponents { get; set; }

    public bool DeepEquals(DestinyCollectibleNodeDetailResponse? other)
    {
        return other is not null &&
               (Collectibles is not null ? Collectibles.DeepEquals(other.Collectibles) : other.Collectibles is null) &&
               (CollectibleItemComponents is not null ? CollectibleItemComponents.DeepEquals(other.CollectibleItemComponents) : other.CollectibleItemComponents is null);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyCollectibleNodeDetailResponse? other)
    {
        if (other is null) return;
        if (!Collectibles.DeepEquals(other.Collectibles))
        {
            Collectibles.Update(other.Collectibles);
            OnPropertyChanged(nameof(Collectibles));
        }
        if (!CollectibleItemComponents.DeepEquals(other.CollectibleItemComponents))
        {
            CollectibleItemComponents.Update(other.CollectibleItemComponents);
            OnPropertyChanged(nameof(CollectibleItemComponents));
        }
    }
}