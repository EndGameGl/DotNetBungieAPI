namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Loadouts;

public class DestinyLoadoutComponent
{
    [JsonPropertyName("colorHash")]
    public uint? ColorHash { get; set; }

    [JsonPropertyName("iconHash")]
    public uint? IconHash { get; set; }

    [JsonPropertyName("nameHash")]
    public uint? NameHash { get; set; }

    [JsonPropertyName("items")]
    public List<Destiny.Components.Loadouts.DestinyLoadoutItemComponent> Items { get; set; }
}
