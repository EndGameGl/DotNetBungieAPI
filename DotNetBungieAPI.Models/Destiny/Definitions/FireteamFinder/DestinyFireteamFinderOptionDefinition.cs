namespace DotNetBungieAPI.Models.Destiny.Definitions.FireteamFinder;

[DestinyDefinition(DefinitionsEnum.DestinyFireteamFinderOptionDefinition)]
public sealed class DestinyFireteamFinderOptionDefinition : IDestinyDefinition, IDisplayProperties
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyFireteamFinderOptionDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    [JsonPropertyName("descendingSortPriority")]
    public int DescendingSortPriority { get; init; }

    [JsonPropertyName("groupHash")]
    public DefinitionHashPointer<Destiny.Definitions.FireteamFinder.DestinyFireteamFinderOptionGroupDefinition> GroupHash { get; init; }

    [JsonPropertyName("codeOptionType")]
    public Destiny.FireteamFinderCodeOptionType CodeOptionType { get; init; }

    [JsonPropertyName("availability")]
    public Destiny.FireteamFinderOptionAvailability Availability { get; init; }

    [JsonPropertyName("visibility")]
    public Destiny.FireteamFinderOptionVisibility Visibility { get; init; }

    [JsonPropertyName("uiDisplayStyle")]
    public string UiDisplayStyle { get; init; }

    [JsonPropertyName("creatorSettings")]
    public Destiny.Definitions.FireteamFinder.DestinyFireteamFinderOptionCreatorSettings? CreatorSettings { get; init; }

    [JsonPropertyName("searcherSettings")]
    public Destiny.Definitions.FireteamFinder.DestinyFireteamFinderOptionSearcherSettings? SearcherSettings { get; init; }

    [JsonPropertyName("values")]
    public Destiny.Definitions.FireteamFinder.DestinyFireteamFinderOptionValues? Values { get; init; }

    /// <summary>
    ///     The unique identifier for this entity. Guaranteed to be unique for the type of entity, but not globally.
    /// <para />
    ///     When entities refer to each other in Destiny content, it is this hash that they are referring to.
    /// </summary>
    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    /// <summary>
    ///     The index of the entity as it was found in the investment tables.
    /// </summary>
    [JsonPropertyName("index")]
    public int Index { get; init; }

    /// <summary>
    ///     If this is true, then there is an entity with this identifier/type combination, but BNet is not yet allowed to show it. Sorry!
    /// </summary>
    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }
}
