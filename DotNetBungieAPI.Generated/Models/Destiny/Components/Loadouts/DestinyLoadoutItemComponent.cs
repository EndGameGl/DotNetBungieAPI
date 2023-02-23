namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Loadouts;

public class DestinyLoadoutItemComponent
{
    [JsonPropertyName("itemInstanceId")]
    public long? ItemInstanceId { get; set; }

    [JsonPropertyName("plugItemHashes")]
    public List<uint> PlugItemHashes { get; set; }
}
