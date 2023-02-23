using DotNetBungieAPI.Models.Destiny.Definitions.Loadouts;

namespace DotNetBungieAPI.Models.Destiny.Components;

public sealed record DestinyLoadoutComponent
{
    [JsonPropertyName("colorHash")]
    public DefinitionHashPointer<DestinyLoadoutColorDefinition> Color { get; init; } = DefinitionHashPointer<DestinyLoadoutColorDefinition>.Empty;

    [JsonPropertyName("iconHash")]
    public DefinitionHashPointer<DestinyLoadoutIconDefinition> Icon { get; init; } = DefinitionHashPointer<DestinyLoadoutIconDefinition>.Empty;

    [JsonPropertyName("nameHash")]
    public DefinitionHashPointer<DestinyLoadoutNameDefinition> Name { get; init; } = DefinitionHashPointer<DestinyLoadoutNameDefinition>.Empty;

    [JsonPropertyName("items")]
    public ReadOnlyCollection<DestinyLoadoutItemComponent> Items { get; init; } = ReadOnlyCollections<DestinyLoadoutItemComponent>.Empty;
}
