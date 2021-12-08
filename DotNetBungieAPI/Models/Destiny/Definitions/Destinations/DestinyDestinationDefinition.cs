using DotNetBungieAPI.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Activities;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.Places;

namespace DotNetBungieAPI.Models.Destiny.Definitions.Destinations;

/// <summary>
///     On to one of the more confusing subjects of the API. What is a Destination, and what is the relationship between
///     it, Activities, Locations, and Places?
///     <para />
///     A "Destination" is a specific region/city/area of a larger "Place". For instance, a Place might be Earth where a
///     Destination might be Bellevue, Washington. (Please, pick a more interesting destination if you come to visit
///     Earth).
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyDestinationDefinition)]
public sealed record DestinyDestinationDefinition : IDestinyDefinition, IDeepEquatable<DestinyDestinationDefinition>
{
    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    /// <summary>
    ///     The place that "owns" this Destination.
    /// </summary>
    [JsonPropertyName("placeHash")]
    public DefinitionHashPointer<DestinyPlaceDefinition> Place { get; init; } =
        DefinitionHashPointer<DestinyPlaceDefinition>.Empty;

    /// <summary>
    ///     If this Destination has a default Free-Roam activity, this is the Activity.
    /// </summary>
    [JsonPropertyName("defaultFreeroamActivityHash")]
    public DefinitionHashPointer<DestinyActivityDefinition> DefaultFreeroamActivity { get; init; } =
        DefinitionHashPointer<DestinyActivityDefinition>.Empty;

    /// <summary>
    ///     If the Destination has default Activity Graphs (i.e. "Map") that should be shown in the director, this is the list
    ///     of those Graphs. At most, only one should be active at any given time for a Destination: these would represent, for
    ///     example, different variants on a Map if the Destination is changing on a macro level based on game state.
    /// </summary>
    [JsonPropertyName("activityGraphEntries")]
    public ReadOnlyCollection<DestinyActivityGraphListEntryDefinition> ActivityGraphEntries { get; init; } =
        ReadOnlyCollections<DestinyActivityGraphListEntryDefinition>.Empty;

    /// <summary>
    ///     This provides the unique identifiers for every bubble in the destination (only guaranteed unique within the
    ///     destination), and any intrinsic properties of the bubble.
    /// </summary>
    [JsonPropertyName("bubbles")]
    public ReadOnlyCollection<DestinyBubbleDefinition> Bubbles { get; init; } =
        ReadOnlyCollections<DestinyBubbleDefinition>.Empty;

    public bool DeepEquals(DestinyDestinationDefinition other)
    {
        return other != null &&
               ActivityGraphEntries.DeepEqualsReadOnlyCollections(other.ActivityGraphEntries) &&
               DisplayProperties.DeepEquals(other.DisplayProperties) &&
               DefaultFreeroamActivity.DeepEquals(other.DefaultFreeroamActivity) &&
               Bubbles.DeepEqualsReadOnlyCollections(other.Bubbles) &&
               //EqualityComparer<ReadOnlyCollection<DestinationBubbleSettingsEntry>>.Default.Equals(BubbleSettings, other.BubbleSettings) &&
               Place.DeepEquals(other.Place) &&
               Blacklisted == other.Blacklisted &&
               Hash == other.Hash &&
               Index == other.Index &&
               Redacted == other.Redacted;
    }

    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyDestinationDefinition;
    [JsonPropertyName("blacklisted")] public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")] public uint Hash { get; init; }

    [JsonPropertyName("index")] public int Index { get; init; }
    [JsonPropertyName("redacted")] public bool Redacted { get; init; }

    public void MapValues()
    {
        foreach (var activityGraphEntry in ActivityGraphEntries) activityGraphEntry.ActivityGraph.TryMapValue();

        DefaultFreeroamActivity.TryMapValue();
        Place.TryMapValue();
    }

    public void SetPointerLocales(BungieLocales locale)
    {
        foreach (var activityGraphEntry in ActivityGraphEntries) activityGraphEntry.ActivityGraph.SetLocale(locale);

        DefaultFreeroamActivity.SetLocale(locale);
        Place.SetLocale(locale);
    }

    public override string ToString()
    {
        return $"{Hash} {DisplayProperties.Name}: {DisplayProperties.Description}";
    }
}