using DotNetBungieAPI.Models.Attributes;
using DotNetBungieAPI.Models.Destiny.Definitions.Common;
using DotNetBungieAPI.Models.Destiny.Definitions.InventoryItems;
using DotNetBungieAPI.Models.Destiny.Definitions.PresentationNodes;
using DotNetBungieAPI.Models.Destiny.Definitions.Vendors;

namespace DotNetBungieAPI.Models.Destiny.Definitions.EventCards;

/// <summary>
///     Defines the properties of an 'Event Card' in Destiny 2, to coincide with a seasonal event for additional challenges, premium rewards, a new seal, and a special title. For example: Solstice of Heroes 2022.
/// </summary>
[DestinyDefinition(DefinitionsEnum.DestinyEventCardDefinition)]
public sealed record DestinyEventCardDefinition : IDestinyDefinition, IDisplayProperties
{
    public DefinitionsEnum DefinitionEnumValue => DefinitionsEnum.DestinyEventCardDefinition;

    [JsonPropertyName("blacklisted")]
    public bool Blacklisted { get; init; }

    [JsonPropertyName("hash")]
    public uint Hash { get; init; }

    [JsonPropertyName("index")]
    public int Index { get; init; }

    [JsonPropertyName("redacted")]
    public bool Redacted { get; init; }

    [JsonPropertyName("displayProperties")]
    public DestinyDisplayPropertiesDefinition DisplayProperties { get; init; }

    [JsonPropertyName("linkRedirectPath")]
    public string LinkRedirectPath { get; init; }

    [JsonPropertyName("color")]
    public DestinyColor Color { get; init; }

    [JsonPropertyName("images")]
    public DestinyEventCardImages Images { get; init; }

    [JsonPropertyName("triumphsPresentationNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> TriumphsPresentationNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("sealPresentationNodeHash")]
    public DefinitionHashPointer<DestinyPresentationNodeDefinition> SealPresentationNode { get; init; } =
        DefinitionHashPointer<DestinyPresentationNodeDefinition>.Empty;

    [JsonPropertyName("ticketCurrencyItemHash")]
    public DefinitionHashPointer<DestinyInventoryItemDefinition> TicketCurrencyItem { get; init; } =
        DefinitionHashPointer<DestinyInventoryItemDefinition>.Empty;

    [JsonPropertyName("ticketVendorHash")]
    public DefinitionHashPointer<DestinyVendorDefinition> TicketVendor { get; init; } =
        DefinitionHashPointer<DestinyVendorDefinition>.Empty;

    [JsonPropertyName("ticketVendorCategoryHash")]
    public uint TicketVendorCategoryHash { get; init; }

    [JsonPropertyName("endTime")]
    public long EndTime { get; init; }
}
