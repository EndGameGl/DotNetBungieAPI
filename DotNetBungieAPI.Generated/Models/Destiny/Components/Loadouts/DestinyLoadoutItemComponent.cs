namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Loadouts;

public class DestinyLoadoutItemComponent
{
    [JsonPropertyName("itemInstanceId")]
    public long ItemInstanceId { get; set; }

    [Destiny2Definition<Destiny.Definitions.DestinyInventoryItemDefinition>("Destiny.Definitions.DestinyInventoryItemDefinition")]
    [JsonPropertyName("plugItemHashes")]
    public uint[]? PlugItemHashes { get; set; }
}
