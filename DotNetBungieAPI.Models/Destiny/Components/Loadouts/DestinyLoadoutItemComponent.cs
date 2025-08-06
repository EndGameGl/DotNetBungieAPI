namespace DotNetBungieAPI.Models.Destiny.Components.Loadouts;

public sealed class DestinyLoadoutItemComponent
{
    [JsonPropertyName("itemInstanceId")]
    public long ItemInstanceId { get; init; }

    [JsonPropertyName("plugItemHashes")]
    public DefinitionHashPointer<Destiny.Definitions.DestinyInventoryItemDefinition>[]? PlugItemHashes { get; init; }
}
