namespace DotNetBungieAPI.Generated.Models.Destiny.Definitions.FireteamFinder;

public class DestinyFireteamFinderOptionDefinition
{
    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; set; }

    [JsonPropertyName("descendingSortPriority")]
    public int? DescendingSortPriority { get; set; }

    [Destiny2Definition<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderOptionGroupDefinition>("Destiny.Definitions.FireteamFinder.DestinyFireteamFinderOptionGroupDefinition")]
    [JsonPropertyName("groupHash")]
    public uint? GroupHash { get; set; }

    [JsonPropertyName("codeOptionType")]
    public Destiny.FireteamFinderCodeOptionType? CodeOptionType { get; set; }

    [JsonPropertyName("availability")]
    public Destiny.FireteamFinderOptionAvailability? Availability { get; set; }

    [JsonPropertyName("visibility")]
    public Destiny.FireteamFinderOptionVisibility? Visibility { get; set; }

    [JsonPropertyName("uiDisplayStyle")]
    public string? UiDisplayStyle { get; set; }

    [JsonPropertyName("creatorSettings")]
    public Destiny.Definitions.FireteamFinder.DestinyFireteamFinderOptionCreatorSettings? CreatorSettings { get; set; }

    [JsonPropertyName("searcherSettings")]
    public Destiny.Definitions.FireteamFinder.DestinyFireteamFinderOptionSearcherSettings? SearcherSettings { get; set; }

    [JsonPropertyName("values")]
    public Destiny.Definitions.FireteamFinder.DestinyFireteamFinderOptionValues? Values { get; set; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint? Hash { get; set; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int? Index { get; set; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool? Redacted { get; set; }
}
