namespace DotNetBungieAPI.Generated.Models.Destiny.Components.Loadouts;

public class DestinyLoadoutComponent
{
    [Destiny2Definition<Destiny.Definitions.Loadouts.DestinyLoadoutColorDefinition>("Destiny.Definitions.Loadouts.DestinyLoadoutColorDefinition")]
    [JsonPropertyName("colorHash")]
    public uint ColorHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Loadouts.DestinyLoadoutIconDefinition>("Destiny.Definitions.Loadouts.DestinyLoadoutIconDefinition")]
    [JsonPropertyName("iconHash")]
    public uint IconHash { get; set; }

    [Destiny2Definition<Destiny.Definitions.Loadouts.DestinyLoadoutNameDefinition>("Destiny.Definitions.Loadouts.DestinyLoadoutNameDefinition")]
    [JsonPropertyName("nameHash")]
    public uint NameHash { get; set; }

    [JsonPropertyName("items")]
    public Destiny.Components.Loadouts.DestinyLoadoutItemComponent[]? Items { get; set; }
}
