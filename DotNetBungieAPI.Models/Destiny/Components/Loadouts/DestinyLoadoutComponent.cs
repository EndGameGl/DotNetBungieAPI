namespace DotNetBungieAPI.Models.Destiny.Components.Loadouts;

public sealed class DestinyLoadoutComponent
{
    [JsonPropertyName("colorHash")]
    public DefinitionHashPointer<Destiny.Definitions.Loadouts.DestinyLoadoutColorDefinition> ColorHash { get; init; }

    [JsonPropertyName("iconHash")]
    public DefinitionHashPointer<Destiny.Definitions.Loadouts.DestinyLoadoutIconDefinition> IconHash { get; init; }

    [JsonPropertyName("nameHash")]
    public DefinitionHashPointer<Destiny.Definitions.Loadouts.DestinyLoadoutNameDefinition> NameHash { get; init; }

    [JsonPropertyName("items")]
    public Destiny.Components.Loadouts.DestinyLoadoutItemComponent[]? Items { get; init; }
}
