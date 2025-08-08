namespace DotNetBungieAPI.Models.Destiny.Definitions.Seasons;

/// <summary>
///     Defines the properties of an 'Event Card' in Destiny 2, to coincide with a seasonal event for additional challenges, premium rewards, a new seal, and a special title. For example: Solstice of Heroes 2022.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyEventCardDefinition)]
public sealed class DestinyEventCardDefinition : IDestinyDefinition, IDisplayProperties
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyEventCardDefinition;

    [JsonPropertyName("displayProperties")]
    public Destiny.Definitions.Common.DestinyDisplayPropertiesDefinition? DisplayProperties { get; init; }

    [JsonPropertyName("linkRedirectPath")]
    public string LinkRedirectPath { get; init; }

    [JsonPropertyName("color")]
    public Destiny.Misc.DestinyColor? Color { get; init; }

    [JsonPropertyName("images")]
    public Destiny.Definitions.Seasons.DestinyEventCardImages? Images { get; init; }

    [JsonPropertyName("triumphsPresentationNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> TriumphsPresentationNodeHash { get; init; }

    [JsonPropertyName("sealPresentationNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> SealPresentationNodeHash { get; init; }

    [JsonPropertyName("eventCardCurrencyList")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition>[]? EventCardCurrencyList { get; init; }

    [JsonPropertyName("ticketCurrencyItemHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition> TicketCurrencyItemHash { get; init; }

    [JsonPropertyName("ticketVendorHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyVendorDefinition> TicketVendorHash { get; init; }

    [JsonPropertyName("ticketVendorCategoryHash")]
    public uint TicketVendorCategoryHash { get; init; }

    [JsonPropertyName("endTime")]
    public long EndTime { get; init; }

    [JsonPropertyName("rewardProgressionHash")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyProgressionDefinition> RewardProgressionHash { get; init; }

    [JsonPropertyName("weeklyChallengesPresentationNodeHash")]
    public DefinitionHashPointer<Destiny.Definitions.Presentation.DestinyPresentationNodeDefinition> WeeklyChallengesPresentationNodeHash { get; init; }

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
