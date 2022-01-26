namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.Checklists;

/// <summary>
///     The properties of an individual checklist item. Note that almost everything is optional: it is *highly* variable what kind of data we'll actually be able to return: at times we may have no other relationships to entities at all.
/// <para />
///     Whatever UI you build, do it with the knowledge that any given entry might not actually be able to be associated with some other Destiny entity.
/// </summary>
public class DestinyChecklistEntryDefinition : IDeepEquatable<DestinyChecklistEntryDefinition>
{
    /// <summary>
    ///     The identifier for this Checklist entry. Guaranteed unique only within this Checklist Definition, and not globally/for all checklists.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; set; }

    /// <summary>
    ///     Even if no other associations exist, we will give you *something* for display properties. In cases where we have no associated entities, it may be as simple as a numerical identifier.
    /// </summary>
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition DisplayProperties { get; set; }

    [JsonPropertyName("destinationHash")]
    public uint? DestinationHash { get; set; }

    [JsonPropertyName("locationHash")]
    public uint? LocationHash { get; set; }

    /// <summary>
    ///     Note that a Bubble's hash doesn't uniquely identify a "top level" entity in Destiny. Only the combination of location and bubble can uniquely identify a place in the world of Destiny: so if bubbleHash is populated, locationHash must too be populated for it to have any meaning.
    /// <para />
    ///     You can use this property if it is populated to look up the DestinyLocationDefinition's associated .locationReleases[].activityBubbleName property.
    /// </summary>
    [JsonPropertyName("bubbleHash")]
    public uint? BubbleHash { get; set; }

    [JsonPropertyName("activityHash")]
    public uint? ActivityHash { get; set; }

    [JsonPropertyName("itemHash")]
    public uint? ItemHash { get; set; }

    [JsonPropertyName("vendorHash")]
    public uint? VendorHash { get; set; }

    [JsonPropertyName("vendorInteractionIndex")]
    public int? VendorInteractionIndex { get; set; }

    /// <summary>
    ///     The scope at which this specific entry can be computed.
    /// </summary>
    [JsonPropertyName("scope")]
    public Destiny.DestinyScope Scope { get; set; }

    public bool DeepEquals(DestinyChecklistEntryDefinition? other)
    {
        return other is not null &&
               Hash == other.Hash &&
               (DisplayProperties is not null ? DisplayProperties.DeepEquals(other.DisplayProperties) : other.DisplayProperties is null) &&
               DestinationHash == other.DestinationHash &&
               LocationHash == other.LocationHash &&
               BubbleHash == other.BubbleHash &&
               ActivityHash == other.ActivityHash &&
               ItemHash == other.ItemHash &&
               VendorHash == other.VendorHash &&
               VendorInteractionIndex == other.VendorInteractionIndex &&
               Scope == other.Scope;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
       PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Update(DestinyChecklistEntryDefinition? other)
    {
        if (other is null) return;
        if (Hash != other.Hash)
        {
            Hash = other.Hash;
            OnPropertyChanged(nameof(Hash));
        }
        if (!DisplayProperties.DeepEquals(other.DisplayProperties))
        {
            DisplayProperties.Update(other.DisplayProperties);
            OnPropertyChanged(nameof(DisplayProperties));
        }
        if (DestinationHash != other.DestinationHash)
        {
            DestinationHash = other.DestinationHash;
            OnPropertyChanged(nameof(DestinationHash));
        }
        if (LocationHash != other.LocationHash)
        {
            LocationHash = other.LocationHash;
            OnPropertyChanged(nameof(LocationHash));
        }
        if (BubbleHash != other.BubbleHash)
        {
            BubbleHash = other.BubbleHash;
            OnPropertyChanged(nameof(BubbleHash));
        }
        if (ActivityHash != other.ActivityHash)
        {
            ActivityHash = other.ActivityHash;
            OnPropertyChanged(nameof(ActivityHash));
        }
        if (ItemHash != other.ItemHash)
        {
            ItemHash = other.ItemHash;
            OnPropertyChanged(nameof(ItemHash));
        }
        if (VendorHash != other.VendorHash)
        {
            VendorHash = other.VendorHash;
            OnPropertyChanged(nameof(VendorHash));
        }
        if (VendorInteractionIndex != other.VendorInteractionIndex)
        {
            VendorInteractionIndex = other.VendorInteractionIndex;
            OnPropertyChanged(nameof(VendorInteractionIndex));
        }
        if (Scope != other.Scope)
        {
            Scope = other.Scope;
            OnPropertyChanged(nameof(Scope));
        }
    }
}